using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Insert(Comment comment)
        {
             await _context.AddAsync(comment);
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments.AsQueryable();
        }

        public async Task<Comment?> Get(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public IQueryable<Comment> GetByProductId(int id)
        {
            return _context.Comments
                           .Where(c => c.ProductId == id)
                           .Include(c => c.User)
                           .OrderByDescending(c => c.AddedAt)
                           .AsQueryable();
        }

        public Task Delete(Comment comment)
        {
            
            _context.Comments.Remove(comment);

            return Task.CompletedTask;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
