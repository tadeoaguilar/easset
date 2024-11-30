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
        public DbSet<Organization> Organization => Set<Organization>();
        public DbSet<Location> Location => Set<Location>();
        public DbSet<Asset> Asset => Set<Asset>();
        public DbSet<Manufacturer> Manufacturer => Set<Manufacturer>();




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.HasDefaultSchema("catalog");
           /* builder.Entity<Tenant>()
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
            builder.Entity<Company>()
                .HasMany(e => e.Organizations)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyID)
                .IsRequired()
                ;
            builder.Entity<Organization>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Organizations)
                .HasForeignKey(e => e.CompanyID)
                .IsRequired()
                ;
            builder.Entity<Organization>()
               .HasMany(e => e.Locations)
               .WithOne(e => e.Organization)
               .HasForeignKey(e => e.OrganizationID)
               .IsRequired()
               ;
           // builder.Entity<Organization>()
             //   .HasMany(e => e.Assets)
               // .WithOne(e => e.Organization)
                //.HasForeignKey(e => e.OrganizationID)
                //.IsRequired()
   ;
            builder.Entity<Location>()
                .HasOne(e => e.Organization)
                .WithMany(e => e.Locations)
                .HasForeignKey(e => e.OrganizationID)
                .IsRequired()
                ;
            

            builder.Entity<Asset>()
                .HasOne(e => e.Organization)
                .WithMany(e => e.Assets)
                .HasForeignKey(e => e.OrganizationID)
                .IsRequired();
           // builder.Entity<Asset>()
             //   .HasOne(e => e.Organization)
               // .WithMany(e => e.Assets)
                //.HasForeignKey(e => e.OrganizationID)
                //.IsRequired();*/


            base.OnModelCreating(builder);

        }

        //TODO- Include Database Extension to create Database at startup
    }
}
