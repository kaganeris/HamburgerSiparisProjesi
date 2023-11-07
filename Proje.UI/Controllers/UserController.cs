using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs;
using Proje.BLL.Validations;
using Proje.DATA.Entities;

namespace Proje.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            LoginDTOValidator validator = new LoginDTOValidator();
            var valid = validator.Validate(loginDTO);
            if (valid.IsValid)
            {
                AppUser appUser = await userManager.FindByNameAsync(loginDTO.UserName);
                if(appUser == null)
                {
                    ViewBag.Uyarı = "Bu isimde kayıtlı kullanıcı bulunmamaktadır.";
                    return View();
                }
                else
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult signInResult = await signInManager.PasswordSignInAsync(appUser, loginDTO.Password,true,false);

                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ViewBag.Uyarı = "Hatalı şifre!";
                    return View();
                }
            }
            foreach (var item in valid.Errors)
            {
                ModelState.AddModelError("LoginHata", item.ErrorMessage);
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            RegisterDTOValidator validator = new();
            var valid = validator.Validate(registerDTO);
            if(valid.IsValid)
            {
                AppUser appUser = mapper.Map<AppUser>(registerDTO);
                IdentityResult result = await userManager.CreateAsync(appUser, registerDTO.Password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "Musteri");
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("KayitHata", item.Description);
                    }
                }
            }
            else
            {
                foreach (var hata in valid.Errors)
                {
                    ModelState.AddModelError("KayitHata", hata.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
