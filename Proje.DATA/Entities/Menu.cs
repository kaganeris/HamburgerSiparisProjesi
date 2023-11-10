using Proje.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Entities
{
    public class Menu : BaseClass
    {
        public Menu()
        {
            SiparislerMenuler = new();
            SepettekiMenuler = new();
        }
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public byte[]? Fotograf { get; set; }
        public List<SiparislerMenuler> SiparislerMenuler { get; set; }
        public List<Sepet> SepettekiMenuler { get; set; }
    }
}
