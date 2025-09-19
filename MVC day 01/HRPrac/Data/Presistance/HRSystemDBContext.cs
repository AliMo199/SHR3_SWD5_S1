using HRPrac.Business.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace HRPrac.Data.Presistence
{
    public class HRSystemDBContext:IdentityDbContext<ApplicationUser>
    {
        public HRSystemDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<HealthBenefit> HealthBenefits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=HRSystem;Integrated Security=True;Trust Server Certificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

    }
}
