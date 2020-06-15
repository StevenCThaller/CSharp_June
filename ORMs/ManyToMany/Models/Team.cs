using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace ManyToMany.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [Display(Name="Team Name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name="HQ Location: ")]
        public string HQLocation { get; set; }
        
        // Navigation Property for Many To Many
        public List<HeroOnTeam> HeroesOnTeam { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}