using Microsoft.EntityFrameworkCore;

namespace CourseAssign.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Crs_Name).HasMaxLength(100);
                entity.Property(c => c.Crs_Desc).HasMaxLength(500);
                entity.Property(c => c.Duration);
            });
        }
    }
}
