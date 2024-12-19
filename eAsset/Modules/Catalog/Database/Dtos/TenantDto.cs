using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Database.Dtos
{
    public record TenantDto(
        string TenantName,
        string TenantCD,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        Guid LicenseId,
        bool Active
        )
    {
      
    }
}
