using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface IPromotionRepository
    {
        IQueryable<Promotion> GetAll();
        Task<Promotion?> Get(int id);

        Task Insert(Promotion item);
        Task Update(Promotion item);
        Task Delete(int id);

        Task Save();

      
    }
}
