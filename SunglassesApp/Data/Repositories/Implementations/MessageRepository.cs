using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddMessage(Message m)
        {
            await _context.AddAsync(m);
        }

        public async Task DeleteMessage(Message m)
        {
            var message = await GetMessage(m.Id);

            if (message == null) throw new Exception("Poruka nije pronadjena");

            _context.Remove(message);
        }
        public Task DeleteAllMessages(string id)
        {
            var messages =  GetAllUserMessages(id).ToList();

            if (messages.Count == 0) throw new Exception("Nema poruka za brisanje");

            _context.Messages.RemoveRange(messages);
            return Task.CompletedTask;
        }

        public IQueryable<Message> GetAllUserMessages(string id)
        {
            return _context.Messages.Where(u => u.RecieverId == id).AsQueryable();
        }

        public async Task<Message?> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

      
    }
}
