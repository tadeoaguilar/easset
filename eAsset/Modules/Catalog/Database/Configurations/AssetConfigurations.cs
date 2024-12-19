using Catalog.Entities;
using Google.Protobuf.Compiler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Database.Configurations
{
    public class AssetConfigurations : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(p => new { p.AssetCD, p.SubNumber });
        }
    }
}
