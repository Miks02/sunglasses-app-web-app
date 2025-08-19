using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        IQueryable<Message> GetAllUserMessages(string id);
        Task<Message?> GetMessage(int id);
        Task DeleteMessage(Message message);
        Task DeleteAllMessages(string id);
        Task AddMessage(Message message);
        Task Save();
        
    }
}
