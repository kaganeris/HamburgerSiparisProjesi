using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs;
using Proje.BLL.Services.Concrete;
using Proje.DATA.Entities;
using Proje.DATA.Repositories;

namespace Proje.UI.Areas.User.Controllers
{
    [Area("User")]
    public class SiparisController : Controller
    {
        private readonly IBaseRepository<Menu> baseRepository;
        SiparisOlusturDTO siparisOlusturDTO;
        MenuService menuService;
        public SiparisController(IBaseRepository<Menu> baseRepository)
        {
            menuService = new(baseRepository);
            this.baseRepository = baseRepository;
            siparisOlusturDTO = new();
            siparisOlusturDTO.Menuler = menuService.GetAll();
        }
        public IActionResult SiparisOlustur()
        {
            return View(siparisOlusturDTO);
        }

        [HttpPost]
        public IActionResult SiparisOlustur(SiparisGonderDTO siparisGonderDTO)
        {
            siparisOlusturDTO.gonderilenSiparisler.Add(siparisGonderDTO);
            return View(siparisOlusturDTO);
        }

        [HttpPost]
        public IActionResult SiparisGonder(SiparisGonderDTO siparisGonderDTO)
        {
            siparisGonderDTO.MenuAdi = menuService.GetById(siparisGonderDTO.MenuID).Adi;
            siparisOlusturDTO.gonderilenSiparisler.Add(siparisGonderDTO);
            return PartialView("_SiparisListesi",siparisOlusturDTO);
        }
        [HttpPost]
        public IActionResult BoyutDegistir(SiparisGonderDTO siparisGonderDTO)
        {
            siparisOlusturDTO.Boyut = siparisGonderDTO.Boyut;
            return PartialView("_Menuler",siparisOlusturDTO);
        }



    }
}
