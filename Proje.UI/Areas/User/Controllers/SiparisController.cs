using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs;
using Proje.BLL.Services.Concrete;
using Proje.DAL.Context;
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

		SiparisOlusturDTO siparisOlusturDTO;
        MenuService menuService;
        SepetService sepetService { get; set; }
        SiparisService siparisService { get; set; }
        SiparisMenulerService siparisMenulerService { get; set; }
        public SiparisController(IBaseRepository<Menu> baseRepository,AppDbContext context,IBaseRepository<Siparis> baseRepository1,IAraTabloRepository<SiparislerMenuler> araTabloRepository)
        {
            siparisService = new(baseRepository1);
            menuService = new(baseRepository);
            sepetService = new(context);
            siparisMenulerService = new(araTabloRepository);

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
            siparisGonderDTO.Sepettekiler = sepetService.GetSepetIncludeMenu(siparisGonderDTO.UserID);

            if(siparisGonderDTO.Sepettekiler.Count > 1 && siparisGonderDTO.ekleme==1)
            {
                return PartialView("_SepetTemizlensinMi", siparisGonderDTO);
            }

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
        
        public IActionResult SiparisOnayla(string id)
        {
            Siparis siparis = new()
            {
                UserID = id
			};
            siparisService.Add(siparis);
			List<Sepet> sepetIcerigi = sepetService.GetWhereAll(x => x.UserId == id);
            foreach(Sepet item in sepetIcerigi)
            {
                if (item.MenuID != null)
                {
                    SiparislerMenuler siparislerMenu = new SiparislerMenuler()
                    {
                        SiparisID = siparis.ID,
                        MenuID = (int)item.MenuID,
                        Boyut = item.Boyut,
                        Adet = item.Adet,
                        TotalFiyat = item.Fiyat
                    };
                    siparisMenulerService.Add(siparislerMenu);
                    sepetService.Delete(item);
                }
            }


            return RedirectToAction("SiparisOlustur");
        }
        [HttpPost]
        public IActionResult SepettenSil(SepettenSilDTO sepettenSilDTO)
        {
            Sepet sepet = (sepetService.GetWhere(x => x.ID == sepettenSilDTO.sepetID));
            if (sepet.Adet > 1)
            {
                sepet.Fiyat = (sepet.Fiyat/sepet.Adet)*(sepet.Adet-1);
                sepet.Adet--;
                sepetService.Update(sepet);
            }
            else
            {
                sepetService.Delete(sepet);
            }
            SiparisGonderDTO siparisGonderDTO = new();
			siparisGonderDTO.Sepettekiler = sepetService.GetWhereAll(x => x.AktifMi == true);

			return PartialView("_SiparisListesi", siparisGonderDTO);
		}
        [HttpPost]
        public IActionResult AdetArttır(SepettenSilDTO sepettenSilDTO)
        {
            Sepet sepet = (sepetService.GetWhere(x => x.ID == sepettenSilDTO.sepetID));
			sepet.Fiyat = (sepet.Fiyat / sepet.Adet) * (sepet.Adet + 1);
			sepet.Adet++;
            sepetService.Update(sepet);
            SiparisGonderDTO siparisGonderDTO = new();
			siparisGonderDTO.Sepettekiler = sepetService.GetWhereAll(x => x.AktifMi == true);

			return PartialView("_SiparisListesi", siparisGonderDTO);
		}
        [HttpPost]
        public IActionResult SepetTemizle(SepetTemizleDTO sepetTemizleDTO)
        {
            foreach(Sepet item in sepetService.GetWhereAll(x=>x.UserId==sepetTemizleDTO.userId))
            {
                sepetService.Delete(item);
            }
            SiparisGonderDTO siparisGonderDTO = new();
            return PartialView("_SiparisListesi", siparisGonderDTO);
        }
        [HttpPost]
        public IActionResult SepetYukle(SepetTemizleDTO sepetTemizleDTO)
        {
            SiparisGonderDTO siparisGonderDTO = new()
            {
                Sepettekiler = sepetService.GetWhereAll(x => x.UserId == sepetTemizleDTO.userId)
            };
            return PartialView("_SiparisListesi", siparisGonderDTO);
        }
    }
}
