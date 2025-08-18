using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;
using SunglassesApp.ViewModels;

namespace SunglassesApp.Controllers
{
    [Authorize(Roles = "User")]
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


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        private string GetUserId()
        {
            return _userManager.GetUserId(User)!;
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutViewModel checkoutVm)
        {
            var cart = await _cartRepository.GetCart(GetUserId());

            var order = new Order
            {
                Status = OrderStatus.Pending,
                UserId = GetUserId(),
                OrderDate = DateTime.Now,
                ShippingAddress = checkoutVm.ShippingAddress + " " + checkoutVm.PostalCode + " " + checkoutVm.City
            };

   
            decimal orderPrice = 0;
            foreach (var cartItem in cart.Items)
            {
                var timesBought = 0;
               
                var product = await _productRepository.Get(cartItem.ProductId);
                if (product == null) throw new Exception("Proizvod nije pronadjen");
                var orderItem = new OrderItem
                {
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    UnitPrice = cartItem.Product.PromoPrice ?? cartItem.Price
                };
                timesBought += orderItem.Quantity;
                orderPrice = orderItem.Quantity * orderItem.UnitPrice + orderPrice;
               // _logger.LogInformation("TIMES BOUGHT: " + orderPrice);
                await _productRepository.Update(product!, timesBought);
                order.Items.Add(orderItem);
            }

            order.OrderPrice = orderPrice + 499.99M;
            try
            {
                await _orderRepository.AddOrder(order);
                await _orderRepository.Save();
                await _cartRepository.ClearCart(GetUserId());
                await _cartRepository.Save();
                return RedirectToAction("Invoice");
            }
            catch(Exception ex)
            {
                _logger.LogError("GREŠKA PRILIKOM PORUČIVANJA... " + ex);
                TempData["ErrorMessage"] = "Došlo je do greške prilikom potvrde porudzbine... Pokušajte ponovo kasnije";
                return RedirectToAction("Index", "Cart");
            }

          
        }
        [HttpGet]
        public async Task<IActionResult> Invoice(int? id)
        {
            var order = await _orderRepository.GetOrderByUserId(GetUserId(), id);


            //if (id != null)
            //{
            //    order = await _orderRepository.GetOrderByUserId(GetUserId(), id);
            //}



            if (order == null) throw new Exception("Porudzbina nije pronadjena");

            return View(order);

        }

        [HttpPost]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var order = await _orderRepository.GetOrderByUserId(GetUserId(), id);

            if (order == null)
            {
                TempData["ErrorMessage"] = "Porudžbina nije pronadjena...\n Pokušajte ponovo kasnije";
                return RedirectToAction("UserOrders");
            }

            try
            {
                await _orderRepository.CancelOrder(order);
                await _orderRepository.Save();
                TempData["SuccessMessage"] = "Porudžbina je uspešno otkazana";
                return RedirectToAction("UserOrders");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Došlo je do greške prilikom otkazivanja porudžbine...\n Pokušajte ponovo kasnije";
                _logger.LogError("GREŠKA! " + ex);
                return RedirectToAction("UserOrders");

            }
        }

        [HttpGet]
        public async Task<IActionResult> UserOrders()
        {
            var orders = await _orderRepository.GetAllUserOrders(GetUserId()).ToListAsync();

            return View(orders);

        }


    }
}
