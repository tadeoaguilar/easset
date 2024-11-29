using Catalog.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Ordering.Application.Data;
using System.Reflection;


namespace Catalog.Infrastructure
{
    public class CatalogContext : DbContext, ICatalogDBContext

    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options) { }

        public DbSet<Tenant> Tenant => Set<Tenant>();
        public DbSet<Company> Company => Set<Company>();



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.HasDefaultSchema("catalog");
            builder.Entity<Tenant>()
                .HasMany(e => e.Companies)
                .WithOne(e => e.Tenant)
                .HasForeignKey(e => e.TenantID)
                .IsRequired()
                ;

            builder.Entity<Company>()
                .HasOne(e => e.Tenant)
                .WithMany(e => e.Companies)
                .HasForeignKey(e => e.TenantID)
                .IsRequired()
                ;


            base.OnModelCreating(builder);

        }

        //TODO- Include Database Extension to create Database at startup
    }
}
