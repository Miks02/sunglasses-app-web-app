using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunglassesApp.Data.Repositories.Interfaces;

namespace SunglassesApp.Controllers
{
    
    [Authorize(Roles = "User")]
    public class CatalogueController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IPromotionRepository _promotionRepository;
        private ILogger<CatalogueController> _logger;

        public CatalogueController(IProductRepository productRepository, IPromotionRepository promotionRepository, ILogger<CatalogueController> logger)
        {
            _productRepository = productRepository;
            _promotionRepository = promotionRepository;
            _logger = logger;
        }
        
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
