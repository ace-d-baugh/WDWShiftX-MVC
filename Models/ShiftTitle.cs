using System.ComponentModel.DataAnnotations;

namespace WDWShiftX.Models
{
    public class ShiftTitle
    {
        public int Id { get; set; }

        // Creation of a new ShiftTitle is behind admin permissions for CoPro or above
        [Required]
        [Display(Name = "Shift Title")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string? Title { get; set; }

        // Role comes from ShiftTitle Database and not needed for this class
        public int CMRoleId { get; set; }
        [Required]
        [Display(Name = "Role")]
        public CMRole? CMRole { get; set; }

        // Property comes from ShiftTitle Database and not needed for this class
        public int PropertyId { get; set; }
        [Required]
        [Display(Name = "Property")]
        public Property? Property { get; set; }
    }
}
