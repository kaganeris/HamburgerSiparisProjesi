using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Models.VMs
{
    public class ConfirmMailVM
    {
        public string Email { get; set; }
        public int ConfirmCode { get; set; }
    }
}
