using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Entities
{
    public class ExtraMalzemelerSiparisler
    {
        public int ID { get; set; }
        [ForeignKey("ExtraMalzeme")]
        public int ExtraMalzemeID { get; set; }

        [ForeignKey("Siparis")]
        public int SiparisID { get; set; }
        public ExtraMalzeme ExtraMalzeme { get; set; }
        public Siparis Siparis { get; set; }
    }
}
