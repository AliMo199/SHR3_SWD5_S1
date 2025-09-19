using HRPrac.Business.Models;
using HRPrac.Business.Interfaces;
using HRPrac.Data.Presistence;
using HRPrac.Data.Repository;
namespace EDU
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(
            //configure => configure.Filters.Add()
                );
            builder.Services.AddDbContext<HRSystemDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IHealthBenefitRepository, HealthBenefitRepository>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                options.Password.RequireUppercase = true)
                .AddEntityFrameworkStores<HRSystemDBContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/" && context.User.Identity.IsAuthenticated)
                {
                    context.Response.Redirect("/Home/Index");
                    return;
                }
                await next();
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}")
                .WithStaticAssets();
            app.Run();
        }
    }
}
