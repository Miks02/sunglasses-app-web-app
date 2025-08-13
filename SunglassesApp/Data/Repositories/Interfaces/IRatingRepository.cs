using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface IRatingRepository
    {
        IQueryable<Rating> GetAll();

        IQueryable<Rating> GetByProductId(int id);

        Task<Rating?> GetByUserId(string userId, int productId);
        Task<Rating?> Get(int id);

        Task Delete(Rating rating);

        Task Insert(Rating rating);

        Task Update(Rating rating);

        Task Save();
    }
}
