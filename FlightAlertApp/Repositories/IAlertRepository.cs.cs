using FlightAlertApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightAlertApp.Repositories
{
    public interface IAlertRepository : IRepository<Alert>
    {
        Task<IEnumerable<Alert>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Alert>> GetActiveAlertsAsync();
    }
}