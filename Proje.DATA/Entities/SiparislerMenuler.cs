using Proje.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Entities
{
    public class SiparislerMenuler
    {
        public int ID { get; set; }
        public int SiparisID { get; set; }
        public int MenuID { get; set; }
        public Siparis Siparis { get; set; }
        public Menu Menu { get; set; }
		public int Adet { get; set; }
		public Boyut Boyut { get; set; }
        public decimal TotalFiyat { get; set; }
	}
}
