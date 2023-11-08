using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;
using System.Data;

namespace Proje.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Musteri")]
    public class SiparisController : Controller
    {
        private readonly IBaseRepository<Menu> baseRepository;
        public SiparisController(IBaseRepository<Menu> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public IActionResult SiparisOlustur(int userID)
        {
            SiparisOlusturDTO siparisOlusturDTO = new(baseRepository)
            {
                UserID = userID,
            };
            return View(siparisOlusturDTO);
        }
        [HttpPost]
        public IActionResult SiparisOlustur(SiparisOlusturDTO siparisOlusturDTO)
        {
            return View(siparisOlusturDTO);
        }
        public IActionResult deneme()
        {
            return PartialView("_SiparisListesi");
        }

    }
}
