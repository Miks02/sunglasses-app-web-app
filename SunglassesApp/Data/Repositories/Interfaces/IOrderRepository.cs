using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
        Task CancelOrder(Order order);
        public Task<Order?> GetOrderByUserId(string userId, int? id);
        public IQueryable<Order> GetAllUserOrders(string userId);

        public Task<Order?> GetOrder(int id);

        public IQueryable<Order> GetAll();

        Task UpdateOrder(Order order, OrderStatus status);
        Task Save();
    }
}
