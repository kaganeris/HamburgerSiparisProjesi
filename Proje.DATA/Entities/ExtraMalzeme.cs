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
        }
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public List<ExtraMalzemelerSiparisler> ExtraMalzemelerSiparisler { get; set; }
    }
}
