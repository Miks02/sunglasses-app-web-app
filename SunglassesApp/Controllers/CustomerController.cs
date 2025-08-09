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
        private readonly ICommentRepository _commentRepository;
        private ILogger<CustomerController> _logger;

        public CustomerController(IProductRepository productRepository, IPromotionRepository promotionRepository,ICommentRepository commentRepository ,ILogger<CustomerController> logger)
        {
            _productRepository = productRepository;
            _promotionRepository = promotionRepository;
            _commentRepository = commentRepository;
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

        [AllowAnonymous]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _productRepository.Get(id);
            var comments =  await _commentRepository.GetByProductId(id).ToListAsync();
            

            if (product == null) return View("Index");

            var productVm = new ProductViewModel
            {
                Id = product.Id,
                Model = product.Model,
                Brand = product.Brand,
                Price = product.Price,
                PromoPrice = product.PromoPrice,
                FrameColor = product.FrameColor,
                FrameType = product.FrameType,
                LensColor = product.LensColor,
                Category = product.Category,
                Gender = product.Gender,
                UVProtection = product.UVProtection,
                PromotionId = product.PromotionId,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Promotion = product.Promotion
            };

            var DetailsVm = new ProductDetailsViewModel
            {
                ProductVm = productVm,
                Comments = comments
            };
           

            return View(DetailsVm);
        }
    }
}
