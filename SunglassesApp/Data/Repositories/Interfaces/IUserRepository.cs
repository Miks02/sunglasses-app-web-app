using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        int GetUsersCount();
        Task<ApplicationUser?> GetUserByUserName(string userName);
    }
}
