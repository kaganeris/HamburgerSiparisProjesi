
using Proje.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Entities
{
    public class Siparis : BaseClass
    {
        public Siparis()
        {
            SiparislerMenuler = new();
            ExtraMalzemelerSiparisler = new();
        }
        public string UserID { get; set; }
        public List<SiparislerMenuler> SiparislerMenuler { get; set; }
        public List<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
        public AppUser AppUser { get; set; }
    }
}
