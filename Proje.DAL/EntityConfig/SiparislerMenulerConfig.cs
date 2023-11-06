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
            builder.HasKey(x => new { x.SiparisID, x.MenuID });
        }
    }
}
