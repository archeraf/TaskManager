using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Configuration
{
    internal class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Project");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired(false);
            builder.Property(e => e.Status)
                .IsRequired();
            builder.Property(e => e.CreatedAt)
                .IsRequired();
            builder.Property(e => e.UpdatedAt);
            builder.Property(e => e.CompletionDate);
            builder.Property(e => e.StartedAt);
            builder.HasMany(p => p.Activities)
            .WithOne(t => t.Project)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
