using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proje.BLL.AutoMapper;
using Proje.BLL.Services.Abstract;
using Proje.BLL.Services.Concrete;
using Proje.DAL.Context;
using Proje.DAL.Repositories;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;
using Proje.UI.Models.SeedData;

namespace Proje.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"));
            });

            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            builder.Services.AddTransient(typeof(IMenuService),typeof(MenuService));

            builder.Services.AddAutoMapper(typeof(MenuMapProfile));

            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/User/Login";

                options.LogoutPath = "/User/Logout";

                options.LoginPath = "/User/Login";

            });

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 8;

                options.Password.RequireUppercase = true;

                options.Password.RequireDigit = true;

                options.Password.RequireLowercase = true;

                options.Password.RequireNonAlphanumeric = true;

                options.User.RequireUniqueEmail = true;

            });

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
            app.UseAuthentication();
            app.UseAuthorization();

            DataSeeder.Seed(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
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