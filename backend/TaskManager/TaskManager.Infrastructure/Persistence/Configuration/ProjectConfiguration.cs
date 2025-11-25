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

            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired(); // NOT NULL

            builder.Property(p => p.Description)
                .HasMaxLength(500)
                .IsRequired(false); // Nullable

            builder.Property(p => p.Status)
                .IsRequired(); // NOT NULL

            // 1 : N relationship between Project and Assignment
            builder.HasMany(p => p.Assignments)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
