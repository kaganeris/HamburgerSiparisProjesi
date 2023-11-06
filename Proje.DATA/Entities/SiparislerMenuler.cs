using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Entities
{
    public class SiparislerMenuler
    {
        public int SiparisID { get; set; }
        public int MenuID { get; set; }
        public Siparis Siparis { get; set; }
        public Menu Menu { get; set; }
    }
}
