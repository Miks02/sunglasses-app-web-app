using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<Rating?> Get(int id)
        {
            return await _context.Ratings.FindAsync(id);
        }
        public  IQueryable<Rating> GetByProductId(int id)
        {
            return _context.Ratings
                    .Where(r => r.ProductId == id)
                    .AsQueryable();
        }

        public async Task<Rating?> GetByUserId(string userId, int productId)
        {
            Rating? userRating = await _context.Ratings.FirstOrDefaultAsync(r => r.UserId == userId && r.ProductId == productId);

            return userRating;

        }

        public IQueryable<Rating> GetAll()
        {
            return _context.Ratings.AsQueryable();
        }

        public Task Delete(Rating rating)
        {
            _context.Ratings.Remove(rating);

           return Task.CompletedTask;
        }


        public async Task Insert(Rating rating)
        {
            await _context.AddAsync(rating);
        }

        public async Task Update(Rating rating)
        {
            var existingRating = await _context.Ratings.FindAsync(rating.Id);

            if (existingRating == null) throw new Exception("Nije pronadjena ocena"); 

            existingRating.Score = rating.Score;


        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
