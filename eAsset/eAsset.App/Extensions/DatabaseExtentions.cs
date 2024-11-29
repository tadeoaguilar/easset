using Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace eAsset.App.Extensions
{
    public static class DatabaseExtentions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<CatalogContext>();

            await context.Database.MigrateAsync();
            
        }
    }
}
