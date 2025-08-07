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

        public IQueryable<Promotion> GetAll()
        {
            return  _context.Promotions.AsQueryable();
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

        public async Task Update(Promotion item)
        {

            var existingPromotion = await _context.Promotions.FindAsync(item.Id);

            if (existingPromotion == null)
                throw new KeyNotFoundException($"Promocija sa unetim ID-em {item.Id} nije pronadjena");

            existingPromotion.Name = item.Name;
            existingPromotion.DiscountPercentage = item.DiscountPercentage;
            existingPromotion.StartDate = item.StartDate;
            existingPromotion.EndDate = item.EndDate;

            
            
        }

        
    }
}
