using System.ComponentModel.DataAnnotations;

namespace WDWShiftX.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "Property Name")]
        public string? PropertyName { get; set; }

        //Virtuals

        public virtual ICollection<CMRole> CMRoles { get; set; } = new HashSet<CMRole>();
        public virtual ICollection<ShiftTitle> ShiftTitles { get; set; } = new HashSet<ShiftTitle>();
    }
}