using FlightAlertApp.Data;
using FlightAlertApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAlertApp.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            // Mock implementation for simplicity
            return await r_dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}