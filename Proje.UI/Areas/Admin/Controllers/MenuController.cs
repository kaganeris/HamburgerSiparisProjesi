using Microsoft.AspNetCore.Mvc;

namespace Proje.UI.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
