using Proje.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Entities
{
    public class ExtraMalzeme : BaseClass
    {
        public ExtraMalzeme()
        {
            ExtraMalzemelerSiparisler = new();
            SepettekiExtraMalzemeler = new();
        }
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public List<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
		public List<Sepet> SepettekiExtraMalzemeler { get; set; }
        public Cesit Cesit { get; set; }
	}
}
