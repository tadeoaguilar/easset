

using Catalog.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Model
{
    public class Tenant: Entity<Guid>
    {
        
        public string TenantCD { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public Guid LicenseID { get; set; } = default!;
        public bool Active { get; set; } = default!;

        public ICollection<Company> Companies { get; } = new List<Company>();
    }
}
