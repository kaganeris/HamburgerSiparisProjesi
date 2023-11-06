using Microsoft.AspNetCore.Mvc;

namespace Proje.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
