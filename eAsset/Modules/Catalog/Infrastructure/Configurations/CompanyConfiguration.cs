using Catalog.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(t => t.Id);
            
            builder.HasIndex(t => t.CompanyCD).IsUnique();
            builder.Property(cb => cb.CompanyCD)
            .HasColumnType("varchar(16)")
            .IsRequired();
        }
    }
}
