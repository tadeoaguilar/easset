

using Catalog.Domain.Abstractions;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Model
{
    public class Company : Entity<Guid>
    {
        public Tenant Tenant { get; set; } = default!;
        public Guid TenantID { get; set; } = default!;
        public string CompanyCD { get; set; } = default!;        
        public string? Description { get; set; } = default!;
        public DateTime StartDate { get; set; } = default!;
        public DateTime EndDate { get; set; } = default!;
        public Guid LicenseID { get; set; } = default!;
        public bool Active { get; set; } = default!;


    }
}
