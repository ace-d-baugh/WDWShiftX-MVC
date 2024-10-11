using System.ComponentModel.DataAnnotations;
using WDWShiftX.Enums;

namespace WDWShiftX.Models
{
    public class Shift
    {
        public int Id { get; set; }

        // ShiftTitle added from ShiftTitle Database in searchable Drop Down Menu
        public int ShiftTitleId { get; set; }

        // StartTime comes from user input
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Shift Start")]
        public DateTime? ShiftStart { get; set; }

        // EndTime comes from user input
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Shift End")]
        public DateTime? ShiftEnd { get; set; }

        // Comments is a text area and comes from user input
        public string? Comments { get; set; }

        // Overtime is a checkbox and comes from user input
        [Required]
        [Display(Name = "Overtime?")]
        public bool Overtime { get; set; } = false;

        // Status is a dropdown and comes from ShiftStatus Enum
        [Required]
        [Display(Name = "Shift Status")]
        public ShiftStatus Status { get; set; } = ShiftStatus.Inactive;

        [Required]
        [Display(Name = "Trade?")]
        public bool Trade { get; set; } = false;

        [Required]
        [Display(Name = "Give Away?")]
        public bool Give { get; set; } = false;

        public virtual ShiftTitle? ShiftTitle { get; set; } // Navigation property for ShiftTitle
        public virtual CMRole? CMRole { get; set; }  // Navigation property for CMRole
        public virtual Property? Property { get; set; }  // Navigation property for Property
    }
}
