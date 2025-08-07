using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Helpers;
using SunglassesApp.Models;
using SunglassesApp.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SunglassesApp.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
            ModelState.Remove("Id");

            if(!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Uneti podaci nisu validni";
                Helper.LogModelErrors(ModelState, _logger, "Uneti podaci nisu validni");

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
;               await _productRepository.ClearPromotions(id);

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

        [HttpGet]
        public async Task<IActionResult> EditPromotion(int id)
        {
            var promotion = await _promotionRepository.Get(id);

            if(promotion == null)
            {
                TempData["ErrorMessage"] = "Promocija nije pronadjena";
                return View("Index");
            }

            var updatedPromotion = new PromotionViewModel
            {
                Name = promotion.Name,
                DiscountPercentage = promotion.DiscountPercentage,
                StartDate = promotion.StartDate,
                EndDate = promotion.EndDate,
                IsEdit = true
            };

            _logger.LogInformation("Pocetni datum: " + updatedPromotion.StartDate);

            return View("PromotionForm", updatedPromotion);
        }

        [HttpPost]
        public async Task<IActionResult> SavePromotion(PromotionViewModel viewModel)
        {

            if(!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Uneti podaci nisu validni";
                Helper.LogModelErrors(ModelState, _logger, "Uneti podaci nisu validni");
                return RedirectToAction("EditPromotion", viewModel);
            }

            var updatedPromotion = new Promotion
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                DiscountPercentage = viewModel.DiscountPercentage,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
            };

            try
            {
                await _promotionRepository.Update(updatedPromotion);
                await _promotionRepository.Save();

                TempData["SuccessMessage"] = "Promocija je uspešno ažurirana";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError("Greška: " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom ažuriranja promocije\nPokušajte ponovo...";
                return RedirectToAction("EditPromotion", viewModel);
            }
        }


    }
}
