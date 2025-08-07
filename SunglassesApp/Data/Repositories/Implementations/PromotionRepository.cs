using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDbContext _context;
        public PromotionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {

            var promotion = await _context.Promotions.FindAsync(id);
            if(promotion == null) 
                throw new KeyNotFoundException($"Promocija sa ID-em {id} nije pronadjena");
           
            _context.Promotions.Remove(promotion);
        }

        public async Task<Promotion?> Get(int id)
        {
            var promotion =  await _context.Promotions.FindAsync(id);
            return promotion;

        }

        public async Task<IEnumerable<Promotion>> GetAll()
        {
            return await _context.Promotions.ToListAsync();
        }

        public Task Insert(Promotion item)
        {
             _context.Promotions.AddAsync(item);
            return Task.CompletedTask;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
            
        }

        public Task Update(Promotion item)
        {
            _context.Promotions.Update(item);
            return Task.CompletedTask;
        }
    }
}
