using System.ComponentModel.DataAnnotations;
using WDWShiftX.Enums;

namespace WDWShiftX.Models
{
    public class Shift
    {
        public int ShiftId { get; set; }

        [Required]
        public string? CastMemberId { get; set; }

        // ShiftTitle added from ShiftTitle Database
        [Required]
        [Display(Name = "Shift Title")]
        public string? ShiftTitleName { get; set; }

        // Role comes from ShiftTitle Database
        [Required]
        public string? Role { get; set;}

        // Property comes from ShiftTitle Database
        [Required]
        public string? Property { get; set;}

        // StartTime comes from user input
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Shift Start")]
        public DateTime? ShiftStart { get; set; }

        // EndTime comes from user input
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Shift End")]
        public DateTime? ShiftEnd { get; set;}

        // Comments is a text area and comes from user input
        public string? Comments { get; set; }

        // Overtime is a checkbox and comes from user input
        [Required]
        [Display(Name = "Overtime?")]
        public bool Overtime { get; set; } = false;

        // Status is a dropdown and comes from ShiftStatus Enum
        [Required]
        [Display(Name = "Shift Status")]
        public ShiftStatus Status { get; set; } = ShiftStatus.Active;
    }
}
