
using Catalog.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace Ordering.Application.Data
{
    public interface ICatalogDBContext
    {
        DbSet<Tenant> Tenant { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
