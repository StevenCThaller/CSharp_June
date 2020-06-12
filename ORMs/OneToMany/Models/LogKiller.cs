using System.ComponentModel.DataAnnotations;

namespace OneToMany.Models
{
    public class LogKiller
    {
        [Required]
        [Display(Name="Alias: ")]
        public string LogAlias { get; set; }
        [Required]
        [Display(Name="Password: ")]
        [DataType(DataType.Password)]
        public string LogPass { get; set; }
    }
}