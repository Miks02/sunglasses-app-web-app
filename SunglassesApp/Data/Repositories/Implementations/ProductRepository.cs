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

        public Task Insert(Product product)
        {
            _context.Products.AddAsync(product);
            return Task.CompletedTask;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
    
            var existingProduct = await _context.Products.FindAsync(product.Id);
            if(existingProduct != null)
            {
                existingProduct.Model = product.Model;
                existingProduct.Brand = product.Brand;
                existingProduct.Category = product.Category;
                existingProduct.ImageUrl = product.ImageUrl;
                existingProduct.Description = product.Description;
                existingProduct.LensColor = product.LensColor;
                existingProduct.FrameColor = product.FrameColor;
                existingProduct.FrameType = product.FrameType;
                existingProduct.Price = product.Price;
                existingProduct.UVProtection = product.UVProtection;
                existingProduct.PromotionId = product.PromotionId;
               

            }

            await _context.SaveChangesAsync();
            
        }
    }
}
