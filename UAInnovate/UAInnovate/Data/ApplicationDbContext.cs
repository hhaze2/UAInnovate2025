using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UAInnovate.Models;

namespace UAInnovate.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<UAInnovate.Models.MaintenanceRequests> MaintenanceRequests { get; set; } = default!;
        public DbSet<UAInnovate.Models.Office> Office { get; set; } = default!;
        public DbSet<UAInnovate.Models.OfficeSupplyRequests> OfficeSupplyRequests { get; set; } = default!;
        public DbSet<UAInnovate.Models.Inventory> Inventory { get; set; } = default!;
    }
}
