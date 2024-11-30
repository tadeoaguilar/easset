﻿using Catalog.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Model
{
    public class Country : Entity<Guid>
    {

        public string CountryCD { get; set; } = default!;
        public string? Description { get; set; } = default!;

        public ICollection<Company> Companies { get; } = new List<Company>();
    }
}
