using Catalog.Database;
using eAsset.App.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Shared.Extensions;



var builder = WebApplication.CreateBuilder(args);
var catalogAssembly = typeof(CatalogModule).Assembly;
builder.Services
    .AddCarterWithAssemblies(catalogAssembly);
builder.Services
    .AddMediatRWithAssemblies(catalogAssembly);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<CatalogContext>((sp, options) =>
{
    //options.UseSqlServer(connectionString);
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("eAsset.App"));
});
builder.Services.AddCatalogModule(builder.Configuration);
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


var app = builder.Build();
app.MapCarter();
// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
 //   await app.InitialiseDatabaseAsync();
}*/

app.UseHttpsRedirection();
//app.UseCatalogModule();

//app.UseMigration<CatalogContext>();

app.Run();


