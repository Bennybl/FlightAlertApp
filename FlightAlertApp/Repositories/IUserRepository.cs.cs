using FlightAlertApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightAlertApp.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}