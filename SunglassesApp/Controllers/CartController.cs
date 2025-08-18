using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.DataTransferObjects;
using SunglassesApp.Models;
using SunglassesApp.ViewModels;
using System.Threading.Tasks;

namespace SunglassesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private UserManager<ApplicationUser> _userManager;
        private ILogger<CartController> _logger;

        public CartController(ICartRepository cartRepository, UserManager<ApplicationUser> userManager ,ILogger<CartController> logger)
        {
            _cartRepository = cartRepository;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _cartRepository.GetCart(GetUserId());

            var cartVm = new CheckoutViewModel
            {
                Cart = items
            };

            return View(cartVm);
        }

        private string GetUserId()
        {
            var userId = _userManager.GetUserId(User);

            return userId == null ? throw new Exception("Korisnik nije ulogovan") : userId;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDTO cartItem)
        {
            var userId = GetUserId();

            var newCartItem = new CartItem
            {

                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price,
            };

            try
            {
                await _cartRepository.AddToCart(userId, newCartItem);
                await _cartRepository.Save();
                return Ok(new { message = "Proizvod je dodat u korpu " + cartItem.Quantity });
            }
            catch(Exception ex)
            {
                _logger.LogError("GREŠKA PRILIKOM DODAVANJA U KORPU" + ex);
                return BadRequest(ex);
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetCart()
        //{
        //    var userId = GetUserId();
        //    try
        //    {
        //        var cart = await _cartRepository.GetCart(userId);
        //        return Ok(cart);
        //    }
        //    catch(Exception ex)
        //    {
        //        _logger.LogError("GREŠKA PRILIKOM DOBIJANJA KORPE" + ex);
        //        return BadRequest(ex);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var userId = GetUserId();
            try
            {
                await _cartRepository.RemoveFromCart(userId, id);
                await _cartRepository.Save();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError("GREŠKA PRILIKOM UKLANJANJA PROIZVODA IZ KORPE" + ex);
                return BadRequest(ex);

            }
        }

        

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            var userId = GetUserId();

            try
            {
                await _cartRepository.ClearCart(userId);
                return Ok(new { message = "Korpa je ociscena" });
            }
            catch(Exception ex)
            {
                _logger.LogError("GREŠKA PRILIKOM ČIŠĆENJA KORPE" + ex);
                return BadRequest(ex);

            }
        }

    }
}
