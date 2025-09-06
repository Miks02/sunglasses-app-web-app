using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;
using SunglassesApp.ViewModels;
using System.Threading.Tasks;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "User")]
    public class RecommendationController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private ILogger<RecommendationController> _logger;
        private IMessageRepository _messageRepository;
        private IUserRepository _userRepository;
        
        public RecommendationController
            (
            UserManager<ApplicationUser> userManager,
            ILogger<RecommendationController> logger,
            IMessageRepository messageRepository,
            IUserRepository userRepository
            )
        {
             _userManager = userManager;
            _logger = logger;
            _messageRepository = messageRepository;
            _userRepository = userRepository;
        }

        private async Task<ApplicationUser> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);
            return user!;
        }

        private string GetUserId()
        {
            return _userManager.GetUserId(User)!;
        }

        public async Task<IActionResult> Index()
        {

            var messages = await _messageRepository.GetAllUserMessages(GetUserId()).ToListAsync();

            return View(messages);
        }

        public async Task<IActionResult> Recommend(ProductDetailsViewModel vm, int productId, string brand, string model)
        {
            string userName = vm.UserName;
            var user = await GetUser();
            var userId = GetUserId();

            try
            {
                var reciever = await _userRepository.GetUserByUserName(userName);
                if(reciever == null)
                {
                    TempData["ErrorMessage"] = "Traženi korisnik nije pronadjen";
                    
                    return RedirectToAction("ProductDetails", "Customer", new { id = productId});
                }
                if(reciever.UserName == user.UserName)
                {
                    TempData["ErrorMessage"] = "Slanje preporuke sebi nije moguće";

                    return RedirectToAction("ProductDetails", "Customer", new { id = productId });
                }

                var message = new Message
                {
                    SenderId = userId,
                    RecieverId = reciever.Id,
                    MessageContent = $"{user.UserName} vam preporučuje proizvod: {brand} {model}",
                    ProductId = productId,
                };



                await _messageRepository.AddMessage(message);
                await _messageRepository.Save();

                TempData["SuccessMessage"] = "Preporuka je uspešno poslata";
                return RedirectToAction("ProductDetails", "Customer", new { id = productId });

            }
            catch (Exception ex)
            {
                _logger.LogError("GREŠKA! " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške... Pokušajte ponovo kasnije";
                return BadRequest();

            }

        }

        public async Task<IActionResult> ClearMessages()
        {

            try
            {
                await _messageRepository.DeleteAllMessages(GetUserId());
                await _messageRepository.Save();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError("GREŠKA! " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom brisanja preporuka... Pokušajte ponovo kasnije";
                return RedirectToAction("Index");
            }
        }

    }
}
