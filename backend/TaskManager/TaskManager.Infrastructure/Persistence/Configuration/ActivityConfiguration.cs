using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Configuration
{
    internal class ActivityConfiguration
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activity");

            builder.HasKey(e => e.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(p => p.Status)
                .IsRequired();

            builder.HasOne(a => a.Project)
                .WithMany(p => p.Activities)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
