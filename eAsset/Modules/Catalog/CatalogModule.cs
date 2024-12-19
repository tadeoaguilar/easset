
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using Catalog.Database;
using Catalog.Abstractions.Data;
using Microsoft.AspNetCore.Builder;
using Shared.Extensions;



namespace Catalog
{
    public static class CatalogModule
    {
        public static IServiceCollection AddCatalogModule(this IServiceCollection services, IConfiguration configuration)

        {
            var connectionString = configuration.GetConnectionString("Database");
            //var connectionString = "Server=localhost;Initial Catalog=CatalogDB;Persist Security Info=False;User ID=sa;Password=T@deo95130031;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";


            services.AddDbContext<CatalogContext>((sp, options) =>
            {

                options.UseSqlServer(connectionString);
            });



            //Esta linea se agrego despues de Ordering.Application
            // services.AddScoped<ICatalogDBContext, CatalogContext>();
            return services;
        }

        public static IApplicationBuilder UseCatalogModule(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.

            // 1. Use Api Endpoint services

            // 2. Use Application Use Case services

            // 3. Use Data - Infrastructure services  
            app.UseMigration<CatalogContext>();

            return app;
        }
    }
}
