using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace OneToMany.Models
{
    public class Killer
    {
        [Key]
        public int KillerId { get; set; } // MAKE SURE YOU KEEP NOTE OF THIS NAME

        [Required]
        [MinLength(2)]
        [Display(Name="First Name: ")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name="Last Name: ")]
        public string LastName { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name="Alias: ")]
        public string Alias { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name="Preferred Weapon: ")]

        public string PreferredWeapon { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Display(Name="Password: ")]
        public string Password { get; set; }

        [Required]
        [NotMapped] // Literally just means that we want this field for the purposes of a form or something
        [MinLength(8)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password: ")]
        public string Confirm { get; set; }

        // Navigation property for all of any given killer's victims
        public List<Victim> ThisKillersVictims { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;



    }
}