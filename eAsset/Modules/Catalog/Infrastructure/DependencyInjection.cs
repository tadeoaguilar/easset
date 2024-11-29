using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Application.Data;



namespace Catalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)

        {
            var connectionString = configuration.GetConnectionString("Database");
         

            services.AddDbContext<CatalogContext>((sp, options) =>
            {
                
                options.UseSqlServer(connectionString);
            });

            //Esta linea se agrego despues de Ordering.Application
            services.AddScoped<ICatalogDBContext, CatalogContext>();
            return services;
        }
    }
}
