using System;
using System.ComponentModel.DataAnnotations;

namespace TwoFormsOnePage.Models
{
    public class Liquor
    {
        [Key]
        public int LiquorId { get; set; }

        [Required]
        public string Brand { get; set; }
        
        [Required]
        public string Type { get; set; }

        [Required]
        public int? Proof { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}