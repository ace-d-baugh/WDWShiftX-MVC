using System.ComponentModel.DataAnnotations;

namespace WDWShiftX.Models
{
    public class CMRole
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Role Name")]
        public string? RoleName { get; set; }

        //Virtuals

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
        public virtual ICollection<ShiftTitle> ShiftTitles { get; set; } = new HashSet<ShiftTitle>();
    }
}
