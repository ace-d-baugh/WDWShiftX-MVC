using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using WDWShiftX.Enums;

namespace WDWShiftX.Models
{
    public class CastMember : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50,ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        public string? LastName { get; set; }

        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }

        public bool NotificationsOn { get; set; } = false;

        [Required]
        public ContactType ContactType { get; set; } = ContactType.none;

        [Required]
        public Ranks Rank { get; set; } = Ranks.Guest;

        // Photo

        // Proficiencies is an array of ShiftTitles selected by the user
    }
}
