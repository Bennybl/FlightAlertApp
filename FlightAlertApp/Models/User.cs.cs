using System;
using System.ComponentModel.DataAnnotations;

namespace FlightAlertApp.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        [StringLength(50)]
        public string First { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Last { get; set; }
        
        public string DeviceToken { get; set; }
    }
}