using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.EntityConfig
{
    public class SiparislerMenulerConfig : IEntityTypeConfiguration<SiparislerMenuler>
    {
        public void Configure(EntityTypeBuilder<SiparislerMenuler> builder)
        {
            builder.HasOne(x=>x.Menu)
                .WithMany(x=>x.SiparislerMenuler)
                .HasForeignKey(x=>x.MenuID);
            builder.HasOne(x => x.Siparis)
                .WithMany(x => x.SiparislerMenuler)
                .HasForeignKey(x => x.SiparisID);
            builder.HasKey("ID");
        }
    }
}
