using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;
using System.Threading.Tasks;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddOrder(Order order)
        {
            await _context.AddAsync(order);
        }

        public async Task CancelOrder(Order order)
        {
            var existingOrder = await _context.Orders.FindAsync(order.Id);

            if (existingOrder == null) throw new Exception("Porudžbina nije pronadjena!");

            existingOrder.Status = OrderStatus.Cancelled;
            
        }

        public async Task<Order?> GetOrderByUserId(string userId, int? id)
        {
            if(id != null)
            {
                return await _context.Orders
                .Where(o => o.UserId == userId && o.Id == id)
                .OrderByDescending(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync();
            }

            return await _context.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .Include(o => o.Items)
                .ThenInclude(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync();
        }

        public  IQueryable<Order> GetAllUserOrders(string userId)
        {
            return  _context.Orders
                .Where(o => o.UserId == userId)
                .AsQueryable();
        }

        public Task ClearUserOrders(List<Order> orders)
        {
            _context.Orders.RemoveRange(orders);
            return Task.CompletedTask;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateOrder(Order order, OrderStatus status)
        {
            var existingOrder = await GetOrder(order.Id);

            if (existingOrder == null) throw new Exception("Porudzbina nije pronadjena");

            existingOrder.Status = status;

            

        }

        public async Task<Order?> GetOrder(int id)
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Items)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public IQueryable<Order> GetAll()
        {
            return _context.Orders
                .OrderByDescending(o => o.OrderDate)
                .Include(o => o.Items)
                .Include(o => o.User)
                .AsQueryable();
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null) throw new Exception("Porudžbina nije pronadjena");

            _context.Orders.Remove(order);

        }
    }
}
