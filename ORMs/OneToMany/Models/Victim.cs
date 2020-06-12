using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;

namespace OneToMany.Models
{
    public class Victim
    {
        [Key]
        public int VictimId { get; set; }

        [Required]
        [MinLength(2)]
        [Display(Name="First Name: ")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(2)]
        [Display(Name="Last Name: ")]
        public string LastName {get; set;}

        [Required]
        [MinLength(3)]
        [Display(Name="Cause of Death: ")]
        public string CauseOfDeath {get; set;}

        [Required]
        [Display(Name="Date of Death: ")]
        public DateTime DateOfDeath { get; set; }

        // Foreign Key for the Killer that this victim is linked to
        // [ForeignKey("Murderer")] -> this is optional in case you don't trust EF
        public int KillerId { get; set; }
        // Navigation property for the Killer that the victim is linked to
        // This is going to come into play when we start talking about the
        // queries
        public Killer Murderer { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}