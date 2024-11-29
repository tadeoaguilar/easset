

using Catalog.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Catalog.Infrastructure.EntityConfigurations
{
    public class TenantConfiguration 
        : IEntityTypeConfiguration<Tenant>
    {
       public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.TenantCD).IsUnique();
            builder.Property(cb => cb.TenantCD)
            .HasColumnType("varchar(16)")            
            .IsRequired();
            
            

        }
    }
}
