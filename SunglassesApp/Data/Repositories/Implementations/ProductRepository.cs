using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product != null)
                _context.Products.Remove(product);
        }

        public async Task<Product?> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task Insert(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Product product)
        {
            _context.Products.Update(product);
            return Task.CompletedTask;
        }
    }
}
