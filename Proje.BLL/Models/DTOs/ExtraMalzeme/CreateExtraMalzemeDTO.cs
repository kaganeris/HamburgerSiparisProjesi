using Proje.DATA.Entities;
using Proje.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Models.DTOs.ExtraMalzeme
{
    public class CreateExtraMalzemeDTO
    {
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public Cesit Cesit { get; set; }
    }
}
