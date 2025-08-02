using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ManageProducts()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

    }
}
