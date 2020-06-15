using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace ManyToMany.Models
{
    public class Hero
    {
        [Key]
        public int HeroId { get; set; }

        [Required]
        [Display(Name="Alias: ")]
        public string Alias { get; set; }

        [Required]
        [Display(Name="First Name: ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Last Name: ")]
        public string LastName { get; set; }

        // Navigation Property for Many To Many
        public List<HeroOnTeam> TeamsPartOf { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}