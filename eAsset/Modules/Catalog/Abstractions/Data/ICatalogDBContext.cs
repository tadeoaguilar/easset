using Catalog.Entities;
using Microsoft.EntityFrameworkCore;


namespace Catalog.Abstractions.Data
{
    public interface ICatalogDBContext
    {
        DbSet<Tenant> Tenant { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
