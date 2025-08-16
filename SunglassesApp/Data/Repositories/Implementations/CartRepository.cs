using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;
using System.Threading.Tasks;
using SunglassesApp.DataTransferObjects;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class CartRepository : ICartRepository
    {
        private ApplicationDbContext _context;
        private ILogger<CartRepository> _logger;

        public CartRepository(ApplicationDbContext context, ILogger<CartRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Cart> GetCart(string userId)
        {
            var cart = await _context.Carts
                .Where(c => c.UserId == userId)
             
                .Include(c => c.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,

                };
                await _context.Carts.AddAsync(cart);
                await Save();
                _logger.LogInformation("KORPA" + cart.Id);
            }
            return cart;
        }

        public async Task AddToCart(string userId, CartItem item)
        {
            var cart = await GetCart(userId);

            if (cart == null) throw new Exception("Korpa nije pronadjena");

            var existingItem = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cart.Id && ci.ProductId == item.ProductId);

            if (existingItem != null) existingItem.Quantity += item.Quantity;
            else
            {
               item.CartId = cart.Id;
               await _context.CartItems.AddAsync(item);

            }         

        }

        public async Task RemoveFromCart(string userId, int itemId)
        {
            var cart = await GetCart(userId);
            var item = await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.Id == itemId && ci.CartId == cart.Id);

            if(item != null)
            {
                _context.CartItems.Remove(item);
                
            }
        }

        public async Task ClearCart(string userId)
        {
            var cart = await GetCart(userId);
            if (cart == null) throw new Exception("Korpa nije pronadjena");

            var items = _context.CartItems.Where(ci => ci.CartId == cart.Id);
            _context.CartItems.RemoveRange(items);
            
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();  
        }

    }
}
