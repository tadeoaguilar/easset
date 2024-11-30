using Catalog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Model
{
    public class CostCenter: Entity<Guid>
    {
        public string CostCenterCD { get; set; } = default!;
        public string? Description { get; set; } = default!;
        public bool Active { get; set; } = default!;

        public ICollection<Asset> Assets { get; } = new List<Asset>();
    }
}
