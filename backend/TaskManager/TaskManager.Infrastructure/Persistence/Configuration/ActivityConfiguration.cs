using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Configuration
{
    internal class ActivityConfiguration
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activities");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.ProjectId)
                .IsRequired();
            builder.Property(e => e.UserId)
                .IsRequired();
            builder.Property(p => p.Title)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(p => p.Status)
                .IsRequired();
            builder.Property(e => e.CompletionDate)
                .IsRequired();
            builder.Property(e => e.CreatedAt);


            builder.HasOne(d => d.Project)
                .WithMany(p => p.Activities)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
