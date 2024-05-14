using System.ComponentModel.DataAnnotations;

namespace WDWShiftX.Models
{
    public class ShiftTitle
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Shift Title")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string? ShiftTitleName { get; set; }

        // Role comes from Role Database
        [Required]
        public string? Role { get; set;}

        // Property comes from Property Database
        [Required]
        public string? Property { get; set;}
    }
}
