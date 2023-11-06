using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.EntityConfig
{
    public class SiparisConfig : BaseConfig<Siparis>
    {
        public override void Configure(EntityTypeBuilder<Siparis> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Adet).IsRequired();

            builder.HasOne(x => x.AppUser).WithMany(x => x.Siparisler).HasForeignKey(x => x.UserID);
        }
    }
}
