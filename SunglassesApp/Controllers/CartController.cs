using Microsoft.AspNetCore.Mvc;

namespace SunglassesApp.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
