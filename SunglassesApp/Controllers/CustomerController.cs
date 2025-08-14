using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.ViewModels;
using SunglassesApp.Models;
using Microsoft.AspNetCore.Identity;
using SunglassesApp.Helpers;


namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "User")]
    public class CustomerController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IRatingRepository _ratingRepository;
        private UserManager<ApplicationUser> _userManager;
        private ILogger<CustomerController> _logger;

        public CustomerController(
            IProductRepository productRepository,
            IPromotionRepository promotionRepository,
            ICommentRepository commentRepository,
            ILogger<CustomerController> logger,
            IRatingRepository ratingRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _productRepository = productRepository;
            _promotionRepository = promotionRepository;
            _commentRepository = commentRepository;
            _ratingRepository = ratingRepository;
            _userManager = userManager;
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string sortOrder, FilterViewModel filter, int page = 1)
        {
            var products = _productRepository.GetAll();

            if (filter.Categories != null && filter.Categories.Count > 0)
                products = products.Where(p => filter.Categories.Contains((int)p.Category!));
            if (filter.FrameColors != null && filter.FrameColors.Count > 0)
                products = products.Where(p => filter.FrameColors.Contains((int)p.FrameColor!));

            if (filter.FrameTypes != null && filter.FrameTypes.Count > 0)
                products = products.Where(p => filter.FrameTypes.Contains((int)p.FrameType!));

            if (filter.LensColors != null && filter.LensColors.Count > 0)
                products = products.Where(p => filter.LensColors.Contains((int)p.LensColor!));

            if (filter.Genders != null && filter.Genders.Count > 0)
                products = products.Where(p => filter.Genders.Contains((int)p.Gender!));

            if (filter.UVProtections != null && filter.UVProtections.Count > 0)
                products = products.Where(p => filter.UVProtections.Contains((int)p.UVProtection!));
            if(filter.Brands != null && filter.Brands.Count > 0)
                products = products.Where(p => filter.Brands.Contains(p.Brand));


            switch (sortOrder)
            {
                case "price_asc":
                    products = products.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(p => p.Price);
                    break;
                case "times_bought":
                    products = products.OrderBy(p => p.TimesBought);
                    break;
                case "default":
                    products = products.OrderBy(p => p.Id);
                    break;
            }

            ViewBag.CurrentSort = sortOrder;

            var productList = await products.ToListAsync();

            return View(productList);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ProductDetails(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            float? userRating = null;
            Rating? rating = null;
            if(currentUser != null)
            {
                rating = await _ratingRepository.GetByUserId(currentUser.Id, id);
                if (rating != null)
                    userRating = rating.Score;
            }

            var product = await _productRepository.Get(id);
            var comments =  await _commentRepository.GetByProductId(id).ToListAsync();
            var ratings = await _ratingRepository.GetByProductId(id).ToListAsync();

            float averageRating = ratings.Any() ? ratings.Average(r => r.Score) : 0;




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
                Promotion = product.Promotion,
                UserRating = userRating,
                UserRatingId = rating?.Id,
                AverageRating = averageRating
            };

            


            var DetailsVm = new ProductDetailsViewModel
            {
                ProductVm = productVm,
                Comments = comments,
                Ratings = ratings
            };
           

            return View(DetailsVm);
        }
    }
}
