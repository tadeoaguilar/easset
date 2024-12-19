﻿using Catalog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Catalog.Database.Configurations
{
    public class TenantConfiguration
        : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.TenantCD).IsUnique();
            builder.HasIndex(t => t.TenantName).IsUnique();
            builder.Property(cb => cb.TenantCD)
            .HasColumnType("varchar(16)")
            .IsRequired();
            builder.Property(cb => cb.TenantName)
            .HasColumnType("varchar(16)")
            .IsRequired();


        }
    }
}
