using Proje.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Models.DTOs
{
    public class UpdateUserDTO
    {
        public string? UserId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DogumTarihi { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
    }
}
