using Catalog.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities
{
    public class LanguageDescr : Entity<Guid>
    {
        public string LanguageCD { get; set; } = default!;
        public string? Description { get; set; } = default!;

        public ICollection<Asset> Asset { get; } = new List<Asset>();

    }
}
