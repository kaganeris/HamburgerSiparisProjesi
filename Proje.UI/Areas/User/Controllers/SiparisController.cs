using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs;
using Proje.BLL.Services.Concrete;
using Proje.DATA.Entities;
using Proje.DATA.Enums;
using Proje.DATA.Repositories;
using System.Data;

namespace Proje.UI.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Musteri,Admin")]
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
            Menu menu = menuService.GetById(siparisGonderDTO.MenuID);

			siparisGonderDTO.MenuAdi = menu.Adi;
            siparisGonderDTO.Fiyat = menu.Fiyat;
            if (siparisGonderDTO.Boyut == Boyut.Büyük) siparisGonderDTO.Fiyat *= 1.4M;
            else if (siparisGonderDTO.Boyut == Boyut.Orta) siparisGonderDTO.Fiyat *= 1.2M;
            siparisGonderDTO.Fiyat *= siparisGonderDTO.Adet;

            return PartialView("_SiparisListesi",siparisGonderDTO);
        }
        [HttpPost]
        public IActionResult BoyutDegistir(SiparisGonderDTO siparisGonderDTO)
        {
            siparisOlusturDTO.Boyut = siparisGonderDTO.Boyut;
            return PartialView("_Menuler",siparisOlusturDTO);
        }



    }
}
