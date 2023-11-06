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
    public class BaseConfig<T> : IEntityTypeConfiguration<T> where T : BaseClass
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.OlusturmaZamani).IsRequired();
            builder.Property(x => x.AktifMi).IsRequired();
        }
    }
}
