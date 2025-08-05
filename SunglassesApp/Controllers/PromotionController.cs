using Microsoft.AspNetCore.Mvc;

namespace SunglassesApp.Controllers
{
    public class PromotionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
