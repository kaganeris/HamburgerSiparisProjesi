using Proje.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Models.DTOs
{
	public class SepetiOnaylaDTO
	{
        public SepetiOnaylaDTO()
        {
            Sepettekiler = new();
        }
        public List<Sepet> Sepettekiler { get; set; }
        public string userId { get; set; }
	}
}
