using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using System.Threading.Tasks;
using SunglassesApp.ViewModels;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "User")]
    public class CustomerController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IPromotionRepository _promotionRepository;
        private ILogger<CustomerController> _logger;

        public CustomerController(IProductRepository productRepository, IPromotionRepository promotionRepository, ILogger<CustomerController> logger)
        {
            _productRepository = productRepository;
            _promotionRepository = promotionRepository;
            _logger = logger;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder, int page = 1)
        {
            var promotions = _productRepository.GetAll();

            switch (sortOrder)
            {
                case "price_asc":
                    promotions = promotions.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    promotions = promotions.OrderByDescending(p => p.Price);
                    break;
                case "times_bought":
                    promotions = promotions.OrderBy(p => p.TimesBought);
                    break;
                case "default":
                    promotions = promotions.OrderBy(p => p.Id);
                    break;

            }

            ViewBag.CurrentSort = sortOrder;

            var promotionList = await promotions.ToListAsync();


            return View(promotionList);
        }
    }
}
