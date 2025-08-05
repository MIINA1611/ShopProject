using Microsoft.EntityFrameworkCore;
using myShop.DataAccess.Data;
using myShop.Infurastructure.IRepository.ServicesRepository;
using myShop.Entites.Models;
using myShop.Infurastructure;
using myShop.Infurastructure.IRepository.Implementation;
using myShop.Infurastructure.IRepository.IServicesRepository;
using myShop.Infurastructure.IRepository;

namespace ShopProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<ShopDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("ShopProject"),
                    sqlOptions => sqlOptions.MigrationsAssembly("myShop.DataAccess")
                )
            );
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IServicesRepositoryLog<LogCategory>, LogCategoryRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Customer",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Admin",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
