using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
        Task CancelOrder(Order order);
        Task<Order?> GetOrderByUserId(string userId, int? id);
        IQueryable<Order> GetAllUserOrders(string userId);
        Task ClearUserOrders(List<Order> orders);

        Task DeleteOrder(int id);
        Task<Order?> GetOrder(int id);

        IQueryable<Order> GetAll();

        Task UpdateOrder(Order order, OrderStatus status);
        Task Save();
    }
}
