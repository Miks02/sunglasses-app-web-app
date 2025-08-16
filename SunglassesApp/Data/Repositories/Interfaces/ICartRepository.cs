using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart> GetCart(string userId);
        Task AddToCart(string userId, CartItem item);
        Task RemoveFromCart(string userId, int itemId);
        Task ClearCart(string userId);
        Task Save();
    }
}
