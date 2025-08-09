using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        IQueryable<Comment> GetAll();

        IQueryable<Comment> GetByProductId(int id);

        Task<Comment?> Get(int id);

        Task Delete(Comment comment);

        Task Insert(Comment comment);

        Task Save();
    }
}
