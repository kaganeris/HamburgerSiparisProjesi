using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Entities
{
    public class BaseClass
    {
        public int ID { get; set; }
        public DateTime OlusturmaZamani { get; set; }
        public DateTime? GuncellemeZamani { get; set; }
        public DateTime? SilinmeZamani { get; set; }
        public bool AktifMi { get; set; }
    }
}
