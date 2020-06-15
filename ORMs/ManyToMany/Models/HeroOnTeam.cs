using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Models
{
    public class HeroOnTeam
    {
        [Key]
        public int HeroOnTeamId { get; set; }

        [Required]
        [Display(Name="Hero: ")]
        public int HeroId { get; set; }
        
        // Navigation Property for the hero
        public Hero Hero { get; set; }


        [Required]
        [Display(Name="Team: ")]
        public int TeamId { get; set; }
        
        // Navigation Property for the team
        public Team Team { get; set; }
        

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}