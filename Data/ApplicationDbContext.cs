using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WDWShiftX.Models;

namespace WDWShiftX.Data
{
    public class ApplicationDbContext : IdentityDbContext<CastMember>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Property> Properties { get; set; } = default!;
        public virtual DbSet<CMRole> CMRoles { get; set; } = default!;
        public virtual DbSet<ShiftTitle> ShiftTitles { get; set; } = default!;
        public virtual DbSet<Shift> Shifts { get; set; } = default!;
    }
}
