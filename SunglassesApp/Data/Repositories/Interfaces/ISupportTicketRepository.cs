using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface ISupportTicketRepository
    {
        IQueryable<SupportTicket> GetAll();

        IQueryable<SupportTicket> GetUserTicket(string userId);

        Task<SupportTicket?> Get(int id);

        Task Delete(SupportTicket ticket);

        Task AddTicket(SupportTicket ticket);

        Task AddMessage(SupportTicketMessage message);

        Task Resolve(SupportTicket ticket);

        Task Save();

    }
}
