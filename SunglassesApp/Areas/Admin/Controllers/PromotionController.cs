using Microsoft.AspNetCore.Mvc;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;
using SunglassesApp.ViewModels;
using System.Threading.Tasks;

namespace SunglassesApp.Controllers
{
    [Area("Admin")]
    public class PromotionController : Controller
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IProductRepository _productRepository;
        private ILogger<PromotionController> _logger;
        public PromotionController(IPromotionRepository promotionRepository, ILogger<PromotionController> logger, IProductRepository productRepository)
        {
            _promotionRepository = promotionRepository;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var promotions = await _promotionRepository.GetAll();

            return View("ManagePromotions",promotions);
        }

        [HttpGet]
        public IActionResult PromotionForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPromotion(PromotionViewModel model)
        {
            if(!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Uneti podaci nisu validni";
                return View("PromotionForm", model);
            }

            var newPromo = new Promotion
            {
                Name = model.Name,
                DiscountPercentage = model.DiscountPercentage,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };

            try
            {
               await _promotionRepository.Insert(newPromo);
               await _promotionRepository.Save();
               TempData["SuccessMessage"] = "Uspešno dodavanje promocije";
            } 
            catch(Exception ex)
            {
                _logger.LogError("Greška: " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilkom dodavanja promocije";
            }

            return View("PromotionForm", model);

        }

        [HttpPost]
        public async Task<IActionResult> DeletePromotion(int id)
        {
            try
            {
          

                await _promotionRepository.Delete(id);
                await _promotionRepository.Save();
                TempData["SuccessMessage"] = "Promocija je uspešno obrisana";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError("Greška: " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom brisanja promocije";
                return RedirectToAction("Index");
            }

            

        }


    }
}
