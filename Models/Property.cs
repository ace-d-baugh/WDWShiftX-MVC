using System.ComponentModel.DataAnnotations;

namespace WDWShiftX.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Property Name")]
        public string? PropertyName { get; set; }
    }
}