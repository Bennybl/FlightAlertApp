using FlightAlertApp.Data;
using FlightAlertApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAlertApp.Repositories
{
    public class AlertRepository : Repository<Alert>, IAlertRepository
    {
        public AlertRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Alert>> GetByUserIdAsync(int userId)
        {
            // Mock implementation for simplicity
            return await r_dbSet.Where(a => a.UserID == userId).ToListAsync();
        }

        public async Task<IEnumerable<Alert>> GetActiveAlertsAsync()
        {
            // Mock implementation for simplicity
            var currentDate = DateTime.Now;
            return await r_dbSet.Where(a => a.DateTo >= currentDate).ToListAsync();
        }
    }
}