using Proje.DATA.Entities;
using Proje.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Models.DTOs
{
    public class SiparisGonderDTO
    {
        public SiparisGonderDTO()
        {
            Sepettekiler = new();
        }
        public int MenuID { get; set; }
        public Boyut Boyut { get; set; }
        public string MenuAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public List<Sepet> Sepettekiler { get; set; }
        public string UserID { get; set; }
    }
}
