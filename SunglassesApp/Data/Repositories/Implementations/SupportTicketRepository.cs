using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class SupportTicketRepository : ISupportTicketRepository
    {
        private ApplicationDbContext _context;
        public SupportTicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Delete(SupportTicket ticket)
        {
            var suppTicket = await _context.SupportTickets.FindAsync(ticket.Id);

            if (suppTicket == null) throw new Exception("Tiket nije pronadjen");

            _context.SupportTickets.Remove(ticket);

        }

        public async Task<SupportTicket?> Get(int id)
        {
            return await _context.SupportTickets
                .Include(t => t.Messages)
                .Include(t => t.Sender)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public IQueryable<SupportTicket> GetAll()
        {
            return _context.SupportTickets
                .Include(t => t.Sender)
                .Include(t => t.Messages)
                .OrderByDescending(t => t.SentAt)
                .AsQueryable();
        }

        public  IQueryable<SupportTicket> GetUserTicket(string userId)
        {
            return _context.SupportTickets
                .Where(s => s.SenderId == userId)
                .Include(t => t.Messages)
                .OrderByDescending(t => t.SentAt)
                .AsQueryable();
        }

        public async Task AddTicket(SupportTicket ticket)
        {
            await _context.SupportTickets.AddAsync(ticket);
        }

        public async Task AddMessage(SupportTicketMessage message)
        {
            await _context.SupportTicketMessages.AddAsync(message);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Resolve(SupportTicket ticket)
        {
            var existingTicket = await Get(ticket.Id);
            if (existingTicket == null) throw new Exception("Tiket nije pronadjen");

            existingTicket.isResolved = true;

            

        }
    }
}
