using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Task<Product?> Get(int id);
        Task  Delete(int id);
        Task Update(Product product, int? timesBought);
        Task Insert(Product product);

        //Task UpdateTimesBought(int id);
        Task<IEnumerable<string>> GetBrands();

        Task ClearPromotions(int id);
        Task Save();

    }
}
