using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.VMs;
using Proje.DATA.Entities;

namespace Proje.UI.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public ConfirmMailController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var value = TempData["Mail"];
            ViewBag.Email = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailVM confirmMailVM)
        {
            if(confirmMailVM.Email != null)
            {
                var user = await userManager.FindByEmailAsync(confirmMailVM.Email);
                if (user.ConfirmCode == confirmMailVM.ConfirmCode)
                {
                    user.EmailConfirmed = true;
                    await userManager.UpdateAsync(user);
                    return RedirectToAction("Login", "User");
                }
                ViewBag.Uyarı = "Hatalı Onay Kodu!";
            }
            return View();
        }
    }
}
