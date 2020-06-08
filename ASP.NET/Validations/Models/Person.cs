using System.ComponentModel.DataAnnotations;

namespace Validations.Models
{
    public class Person
    {
        [Required(ErrorMessage="Hey, you should probably actually fill out this field.")]
        [MinLength(2, ErrorMessage="That's too short! The name should be at least 2 characters!")]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need enter an age?")]
        [Range(18, double.PositiveInfinity, ErrorMessage="You're too young.")]
        [Display(Name = "Age: ")]
        public int? Age { get; set; }

        // [EmailAddress]
        // public string Email { get; set; }


        // public string FieldOne { get; set; }

        // [Compare("FieldOne")]
        // public string FieldTwo { get; set; }


        [Required(ErrorMessage="Bad hackerman!!")]
        [Display(Name = "Favorite Color: ")]
        public string FavoriteColor { get; set; }
    }
}