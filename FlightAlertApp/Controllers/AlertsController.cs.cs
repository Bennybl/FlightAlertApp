using FlightAlertApp.Models;
using FlightAlertApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlightAlertApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertRepository r_alertRepository;
        private readonly IUserRepository r_userRepository;

        public AlertsController(IAlertRepository alertRepository, IUserRepository userRepository)
        {
            r_alertRepository = alertRepository;
            r_userRepository = userRepository;
        }

        // GET: api/Alerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAlerts()
        {
            try
            {
                var alerts = await r_alertRepository.GetAllAsync();
                return Ok(alerts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Alerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alert>> GetAlert(int id)
        {
            try
            {
                var alert = await r_alertRepository.GetByIdAsync(id);

                if (alert == null)
                {
                    return NotFound();
                }

                return alert;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Alerts/user/5
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAlertsByUser(int userId)
        {
            try
            {
                var user = await r_userRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return NotFound($"User with ID {userId} not found");
                }

                var alerts = await r_alertRepository.GetByUserIdAsync(userId);
                return Ok(alerts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/Alerts
        [HttpPost]
        public async Task<ActionResult<Alert>> CreateAlert(Alert alert)
        {
            try
            {
                var user = await r_userRepository.GetByIdAsync(alert.UserID);
                if (user == null)
                {
                    return BadRequest($"User with ID {alert.UserID} does not exist");
                }

                await r_alertRepository.AddAsync(alert);

                return CreatedAtAction(nameof(GetAlert), new { id = alert.AlertID }, alert);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/Alerts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlert(int id, Alert alert)
        {
            if (id != alert.AlertID)
            {
                return BadRequest();
            }

            try
            {
                var user = await r_userRepository.GetByIdAsync(alert.UserID);
                if (user == null)
                {
                    return BadRequest($"User with ID {alert.UserID} does not exist");
                }

                await r_alertRepository.UpdateAsync(alert);;
            }
            catch (Exception ex)
            {
                var existingAlert = await r_alertRepository.GetByIdAsync(id);
                if (existingAlert == null)
                {
                    return NotFound();
                }
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }

        // DELETE: api/Alerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            try
            {
                var alert = await r_alertRepository.GetByIdAsync(id);
                if (alert == null)
                {
                    return NotFound();
                }

                await r_alertRepository.DeleteAsync(alert);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Alerts/active
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Alert>>> GetActiveAlerts()
        {
            try
            {
                var alerts = await r_alertRepository.GetActiveAlertsAsync();
                return Ok(alerts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


    }
}