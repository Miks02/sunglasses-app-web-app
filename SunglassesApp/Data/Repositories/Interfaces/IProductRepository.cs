using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> Get(int id);
        Task  Delete(int id);
        Task Update(Product product);
        Task Insert(Product product);

        Task Save();
    }
}
