using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proje.DAL.EntityConfig;
using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Menu> Menuler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<ExtraMalzeme> ExtraMalzemeler { get; set; }
        public DbSet<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
        public DbSet<SiparislerMenuler> SiparislerMenuler { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ExtraMalzemeConfig());
            builder.ApplyConfiguration(new ExtraMalzemelerSiparislerConfig());
            builder.ApplyConfiguration(new MenuConfig());
            builder.ApplyConfiguration(new SiparisConfig());
            builder.ApplyConfiguration(new SiparislerMenulerConfig());

            base.OnModelCreating(builder);
        }
    }
}
