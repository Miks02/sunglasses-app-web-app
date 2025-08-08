using Microsoft.AspNetCore.Mvc;

namespace SunglassesApp.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
