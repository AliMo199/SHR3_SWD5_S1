using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Core.Entities;

namespace TaskManagement.Infrastructure.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Description)
                .HasMaxLength(500);

            builder.Property(t => t.IsCompleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(t => t.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(t => t.DueDate)
                .IsRequired(false);
        }
    }
}