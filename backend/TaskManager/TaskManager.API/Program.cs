using EvolveDb;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Polly;
using Serilog;
using TaskManager.Application.DependencyInjection;
using TaskManager.Infrastructure.DI;
using TaskManager.Infrastructure.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    MigrateDatabase(connectionString);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



void MigrateDatabase(string connectionStr)
{
    try
    {
        var policy = Policy
            .Handle<Exception>()
            .WaitAndRetry(
                retryCount: 5,
                sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                onRetry: (exception, timeSpan, retryCount, context) =>
                {
                    Log.Warning($"Banco de dados indisponível. Tentativa {retryCount}/5. Erro: {exception.Message}");
                }
            );

        policy.Execute(() =>
        {
            using var evolveConnection = new MySqlConnection(connectionStr);

            var evolve = new Evolve(evolveConnection, Log.Information)
            {
                Locations = new List<string> { "db/migrations", "db/dataset" },
                IsEraseDisabled = true,
            };

            evolve.Migrate();
        });

        Log.Information("Migração de banco de dados concluída com sucesso.");
    }
    catch (Exception ex)
    {
        Log.Error("Falha crítica na migração do banco de dados após retentativas.", ex);
        throw;
    }

}