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
        public static async void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = serviceScope.ServiceProvider.GetService<AppDbContext>();


                context.Database.Migrate();

                if (!context.Roles.Any())
                {
                    await context.Roles.AddRangeAsync(
                        new IdentityRole() { Name = "Musteri", NormalizedName = "MUSTERI" },
                        new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" }
                        );
                }
                await context.SaveChangesAsync();

                if (!context.Users.Any())
                {
                    PasswordHasher<AppUser> password = new();
                    AppUser appUser = new AppUser() { Ad = "Admin", Soyad = "Admin", UserName = "admin", NormalizedUserName = "ADMIN", DogumTarihi = new DateTime(1990, 01, 01), Cinsiyet = DATA.Enums.Cinsiyet.Erkek, Email = "admin@admin.com", NormalizedEmail = "ADMIN@ADMIN.COM", EmailConfirmed = true };

                    context.Users.AddRange(appUser);
                    var hashed = password.HashPassword(appUser, "Admin12.");
                    appUser.PasswordHash = hashed;

                    var userStore = new UserStore<AppUser>(context);
                    await userStore.AddToRoleAsync(appUser, "ADMIN");
                }
                await context.SaveChangesAsync();
                if (!context.Menuler.Any())
                {

                    using (HttpClient client = new HttpClient())
                    {
                        List<string> menuUrlList = MenuUrl();
                        List<byte[]> imageBytes = new List<byte[]>();
                        foreach (string item in menuUrlList)
                        {
                            imageBytes.Add(await client.GetByteArrayAsync(item));
                        }
                        List<Menu> menuler = new List<Menu>()
                    {
                        new Menu() {Adi = "Classic",Fiyat = 150,Fotograf = imageBytes[0], AktifMi = true,OlusturmaZamani = DateTime.Now },
                        new Menu() {Adi = "CheeseBurger",Fiyat = 170,Fotograf = imageBytes[1],AktifMi = true,OlusturmaZamani = DateTime.Now},
                        new Menu() {Adi = "Acılı Burger",Fiyat = 120,Fotograf = imageBytes[2], AktifMi = true, OlusturmaZamani = DateTime.Now},
                        new Menu() {Adi = "DoubleBurger",Fiyat = 150,Fotograf = imageBytes[3], AktifMi = true, OlusturmaZamani = DateTime.Now},
                        new Menu() {Adi = "Tavuk Burger",Fiyat = 100,Fotograf = imageBytes[4], AktifMi = true,OlusturmaZamani = DateTime.Now},

                    };
                        context.Menuler.AddRange(menuler);
                    }

                }
                context.SaveChanges();

                if (!context.ExtraMalzemeler.Any())
                {
                    List<ExtraMalzeme> extras = new List<ExtraMalzeme>()
                    {
                        new ExtraMalzeme()
                        {
                            Adi="Ketçap", Fiyat=5 ,Cesit=DATA.Enums.Cesit.Sos,AktifMi = true, OlusturmaZamani = DateTime.Now
                        }, 

                        new ExtraMalzeme()
                        {
                            Adi="Mayonez", Fiyat=5 ,Cesit=DATA.Enums.Cesit.Sos,AktifMi = true, OlusturmaZamani = DateTime.Now
                        }, 

                        new ExtraMalzeme()
                        {
                            Adi="Ranch Sos", Fiyat=5 ,Cesit=DATA.Enums.Cesit.Sos,AktifMi = true, OlusturmaZamani = DateTime.Now
                        }, 
                        new ExtraMalzeme()
                        {
                            Adi="Barbekü Sos", Fiyat=5 ,Cesit=DATA.Enums.Cesit.Sos,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                         new ExtraMalzeme()
                        {
                            Adi="Sufle", Fiyat=5 ,Cesit=DATA.Enums.Cesit.Tatlı,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                          new ExtraMalzeme()
                        {
                            Adi="Patates Kızartması", Fiyat=45 ,Cesit=DATA.Enums.Cesit.Aperatif,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                          new ExtraMalzeme()
                        {
                            Adi="Mac&Cheese Balls", Fiyat=60 ,Cesit=DATA.Enums.Cesit.Aperatif,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                          new ExtraMalzeme()
                        {
                            Adi="Mozarella Sticks", Fiyat=70 ,Cesit=DATA.Enums.Cesit.Aperatif,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                          new ExtraMalzeme()
                        {
                            Adi="Dondurma", Fiyat=20 ,Cesit=DATA.Enums.Cesit.Tatlı,AktifMi = true, OlusturmaZamani = DateTime.Now
                        },
                    };
                    context.ExtraMalzemeler.AddRange(extras);
                }
                context.SaveChanges();


            }
        }
        private static List<string> MenuUrl()
        {
            List<string> menuUrl = new List<string>();

            string bigKing = "https://www.burgerking.com.tr/cmsfiles/products/big-king-menu.png?v=305";
            menuUrl.Add(bigKing);

            string whooper = "https://d3vkdqr0qjxhag.cloudfront.net/burger-king/whopper_menu_2b7dbd274f.webp";
            menuUrl.Add(whooper);

            string kingChicken = "https://www.burgerking.com.tr/cmsfiles/products/king-chicken-menu.png?v=305";
            menuUrl.Add(kingChicken);

            string bigMac = "https://www.diyetkolik.com/site_media/media/nutrition_images/66A245CD-4EA3-4F2D-B498-0E1EA75D1EB4.jpeg";
            menuUrl.Add(bigMac);

            string tavukBurger = "https://www.burgerking.com.tr/cmsfiles/products/tavukburger-menu.png?v=305";
            menuUrl.Add(tavukBurger);

            return menuUrl;
        }
    }
}
