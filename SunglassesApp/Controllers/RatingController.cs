using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SunglassesApp.Data.Repositories.Implementations;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "User")]
    public class RatingController : Controller
    {
        private IRatingRepository _ratingRepository;
        private ILogger<RatingController> _logger;
        public RatingController(IRatingRepository ratingRepository, ILogger<RatingController> logger)
        {
            _ratingRepository = ratingRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Rate(int id, string isEdit,int productId, string userId, string value)
        {
            float score = float.Parse(value);
            bool edit = bool.Parse(isEdit);
            _logger.LogInformation("Da li se ocena edituje? " + isEdit);
            if (edit)
            {
                await EditRating(id, productId, userId, score);
                _logger.LogInformation("Edit ocene");
            }
            else
            {
                await AddRating(score, userId, productId);
                _logger.LogInformation("Dodavanje ocene");
            }

            return RedirectToAction("ProductDetails", "Customer", new { id = productId });


           
        }
        public async Task AddRating(float score, string userId, int productId)
        {

            var rating = new Rating
            {
                ProductId = productId,
                UserId = userId,
                Score = score
            };

            try
            {
                await _ratingRepository.Insert(rating);
                await _ratingRepository.Save();

            }
            catch (Exception ex)
            {
                _logger.LogError("Došlo je do greške prilikom dodeljivanja ocene... \n" + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom dodeljivanja ocene, pokušajte ponovo";
                

            }

        }

        public async Task<IActionResult> EditRating(int id, int productId, string userId, float score)
        {
            
            var rating = await _ratingRepository.Get(id);

            if (rating == null) return NotFound();

            var updatedRating = new Rating
            {
                Id = id,
                ProductId = productId,
                UserId = userId,
                Score = score
            };

            try
            {
                await _ratingRepository.Update(updatedRating);
                await _ratingRepository.Save();
            }
            catch(Exception ex)
            {
                _logger.LogError("Došlo je do greške prilikom menjanja ocene... \n" + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom menjanja ocene, pokušajte ponovo";
                return NotFound();
            }
            return RedirectToAction("ProductDetails", "Customer", new { id = productId });


        }

    }
}
