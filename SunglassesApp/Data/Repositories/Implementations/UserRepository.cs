using Microsoft.EntityFrameworkCore;
using SunglassesApp.Data.Repositories.Interfaces;
using SunglassesApp.Models;

namespace SunglassesApp.Data.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetUsersCount()
        {
            int usersCount = _context.Users
            .Where(u => _context.UserRoles
                .Any(ur => ur.UserId == u.Id && _context.Roles
                    .Any(r => r.Id == ur.RoleId && r.Name == "User")))
            .Count();
            return usersCount;
        }
    }
}
