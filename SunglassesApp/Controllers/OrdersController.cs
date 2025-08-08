using Microsoft.AspNetCore.Mvc;

namespace SunglassesApp.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
