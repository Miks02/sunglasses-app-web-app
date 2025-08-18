using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SunglassesApp.Controllers;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;

namespace SunglassesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private ICartRepository _cartRepository;
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;
        private ILogger<OrderController> _logger;
        private UserManager<ApplicationUser> _userManager;


        public OrderController
            (
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository,
            ILogger<OrderController> logger,
            UserManager<ApplicationUser> userManager
            )
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _logger = logger;
            _userManager = userManager;
        }

        
        public IActionResult Index()
        {
            var orders = _orderRepository.GetAll();

            return View(orders);
        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var order = await _orderRepository.GetOrder(id);

            return View(order);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, OrderStatus status)
        {
            var order = await _orderRepository.GetOrder(id);

            if(order == null)
            {
                TempData["ErrorMessage"] = "Porudžbina nije pronadjena... Pokušajte ponovo kasnije";
                return RedirectToAction("Index");
            }

            try
            {
                await _orderRepository.UpdateOrder(order, status);
                await _orderRepository.Save();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                _logger.LogError("GREŠKA! " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom ažuriranja statusa porudžbine... Pokušajte ponovo kasnije";
                return RedirectToAction("Index");
            }

        }
    }
}
