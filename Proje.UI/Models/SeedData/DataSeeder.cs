using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using Proje.DAL.Context;
using Proje.DATA.Entities;

namespace Proje.UI.Models.SeedData
{
    public static class DataSeeder
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = serviceScope.ServiceProvider.GetService<AppDbContext>();


                context.Database.Migrate();

                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(
                        new IdentityRole() { Name = "Musteri",NormalizedName="MUSTERI" },
                        new IdentityRole() { Name = "Admin",NormalizedName="ADMIN" }
                        );
                }

                if(!context.Users.Any())
                {
                    PasswordHasher<AppUser> password = new();
                    AppUser appUser = new AppUser() { Ad = "Admin", Soyad = "Admin", UserName = "admin",NormalizedUserName="ADMIN", DogumTarihi = new DateTime(1990, 01, 01), Cinsiyet = DATA.Enums.Cinsiyet.Erkek, Email = "admin@admin.com",NormalizedEmail="ADMIN@ADMIN.COM", EmailConfirmed = true };
                        
                    context.Users.AddRange(appUser);
                    var hashed = password.HashPassword(appUser,"Admin12.");
                    appUser.PasswordHash = hashed;

                    var userStore = new UserStore<AppUser>(context);
                    userStore.AddToRoleAsync(appUser, "Admin");
                }
                context.SaveChanges();


            }
        }
    }
}
