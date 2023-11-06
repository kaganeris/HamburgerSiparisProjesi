using Microsoft.AspNetCore.Identity;
using Proje.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DATA.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Siparisler = new();
        }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public List<Siparis> Siparisler { get; set; }
    }
}
