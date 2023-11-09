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
        private readonly IBaseRepository<Sepet> _baseRepository;
        private readonly IBaseRepository<Siparis> baseRepository1;

		SiparisOlusturDTO siparisOlusturDTO;
        MenuService menuService;
        SepetService sepetService { get; set; }
        SiparisService siparisService { get; set; }
        public SiparisController(IBaseRepository<Menu> baseRepository,IBaseRepository<Sepet> _baseRepository,IBaseRepository<Siparis> baseRepository1)
        {
            siparisService = new(baseRepository1);
            menuService = new(baseRepository);
            sepetService = new(_baseRepository);
            this.baseRepository = baseRepository;
            this._baseRepository = _baseRepository;
            this.baseRepository1=baseRepository1;
            siparisOlusturDTO = new();
            siparisOlusturDTO.Menuler = menuService.GetAll();
        }
        public IActionResult SiparisOlustur()
        {
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
            Sepet sepet = new Sepet()
            {
                MenuID = siparisGonderDTO.MenuID,
                Adet = siparisGonderDTO.Adet,
                Boyut = siparisGonderDTO.Boyut,
                Fiyat = siparisGonderDTO.Fiyat,
                UserId=siparisGonderDTO.UserID,
                AktifMi = true
            };
            
            sepetService.Add(sepet);
            siparisGonderDTO.Sepettekiler=sepetService.GetWhereAll(x=>x.AktifMi==true);

            return PartialView("_SiparisListesi",siparisGonderDTO);
        }
        [HttpPost]
        public IActionResult BoyutDegistir(SiparisGonderDTO siparisGonderDTO)
        {
            siparisOlusturDTO.Boyut = siparisGonderDTO.Boyut;
            return PartialView("_Menuler",siparisOlusturDTO);
        }

        public IActionResult SepetiOnayla()
        {
            SepetiOnaylaDTO sepetiOnaylaDTO = new()
            {
                Sepettekiler = sepetService.GetWhereAll(x => x.AktifMi == true)
            };
            return View(sepetiOnaylaDTO);
        }
        public IActionResult SiparisOnayla()
        {
            List<Sepet> sepetIcerigi = sepetService.GetWhereAll(x => x.AktifMi == true);
            foreach(var item in sepetIcerigi)
            {
                if (item.MenuID != null)
                {

                }
            }

			Siparis siparis = new()
            {

            };
            foreach(var item in sepetService.GetWhereAll(x => x.AktifMi == true))
            {

                sepetService.Delete(item);
            }

            return RedirectToAction("SiparisOlustur");
        }
        [HttpPost]
        public IActionResult SepettenSil(SepettenSilDTO sepettenSilDTO)
        {

            sepetService.Delete(sepetService.GetWhere(x => x.ID == sepettenSilDTO.sepetID));
            SiparisGonderDTO siparisGonderDTO = new();
			siparisGonderDTO.Sepettekiler = sepetService.GetWhereAll(x => x.AktifMi == true);

			return PartialView("_SiparisListesi", siparisGonderDTO);
		}




    }
}
