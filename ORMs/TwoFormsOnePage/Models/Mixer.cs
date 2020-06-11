using System.ComponentModel.DataAnnotations;
using System;

namespace TwoFormsOnePage.Models
{
    public class Mixer
    {
        [Key]
        public int MixerId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Flavor { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}