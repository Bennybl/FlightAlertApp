using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightAlertApp.Models
{
    public class Alert
    {
        [Key]
        public int AlertID { get; set; }
        
        [Required]
        public int UserID { get; set; }
        
        [Required]
        public DateTime DateFrom { get; set; }
        
        [Required]
        public DateTime DateTo { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Origin { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Destination { get; set; }
        
        [Required]
        public decimal MaxPrice { get; set; }
        
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}