using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        DbSet<Project> Projects { get; set; }
        DbSet<Activity> Activities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(1000);
                entity.Property(e => e.Status)
                    .IsRequired();
                entity.Property(e => e.CreatedAt)
                    .IsRequired();
                entity.Property(e => e.UpdatedAt);
                entity.Property(e => e.FinishedAt);
                entity.Property(e => e.StartedAt);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ProjectId)
                    .IsRequired();
                entity.Property(e => e.UserId)
                    .IsRequired();
                entity.Property(e => e.CompletionDate)
                    .IsRequired();
                entity.Property(e => e.CreatedAt);
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }


    }
}
