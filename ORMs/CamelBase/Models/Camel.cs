using System.ComponentModel.DataAnnotations;
using System;

namespace CamelBase.Models
{
    public class Camel 
    {
        [Key]
        public int CamelId { get; set; }

        [Required(ErrorMessage="Bro, you gotta put a camel name.")]
        [MinLength(2, ErrorMessage="The camel name should at least be 2 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage="Time is real now, you can't just not have an age.")]
        [Range(0,double.PositiveInfinity, ErrorMessage="C'mon, your camel can't be negative years old.")]
        public int? Age { get; set; }

        [Required(ErrorMessage="It's not a camel if it doesn't have humps!!")]
        [Range(1,4,ErrorMessage="Let's be real with the number of humps.")]
        public int? Humps { get; set; }

        [Required(ErrorMessage="But how am I supposed to see the camel without a picture?!")]
        public string ImageUrl { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}