using Catalog.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities
{
    public class License : Entity<Guid>
    {
        public string LicenseCD { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public bool Active { get; set; } = default!;
        public ICollection<Tenant> Tenants { get; } = new List<Tenant>();
    }
}
