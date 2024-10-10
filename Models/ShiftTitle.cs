using System.ComponentModel.DataAnnotations;

namespace WDWShiftX.Models
{
    public class ShiftTitle
    {
        public int Id { get; set; }

        // Creation of a new ShiftTitle is behind admin permissions for CoPro or above
        [Required]
        [Display(Name = "Shift Name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string? ShiftName { get; set; }

        // Role comes from ShiftTitle Database and not needed for this class
        [Required]
        [Display(Name = "Role")]
        public int? CMRoleId { get; set; }

        // Property comes from ShiftTitle Database and not needed for this class
        [Required]
        [Display(Name = "Property")]
        public int? PropertyId { get; set; }

        public virtual CMRole? CMRole { get; set; }  // Navigation property for CMRole
        public virtual Property? Property { get; set; }  // Navigation property for Property
    }
}
