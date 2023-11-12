using Proje.BLL.Services.Concrete;
using Proje.DATA.Entities;
using Proje.DATA.Enums;
using Proje.DATA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Models.DTOs
{
    public class SiparisOlusturDTO
    {
        public SiparisOlusturDTO()
        {
            Menuler = new();
            ExtraMalzemeler = new();
        }
        public List<Menu> Menuler { get; set; }
        public Boyut Boyut { get; set; }
        public List<ExtraMalzeme> ExtraMalzemeler { get; set; } 
    }
}
