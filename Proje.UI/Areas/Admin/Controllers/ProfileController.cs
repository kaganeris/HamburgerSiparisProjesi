using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Proje.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Settings()
		{
			return View();
		}
	}
}
