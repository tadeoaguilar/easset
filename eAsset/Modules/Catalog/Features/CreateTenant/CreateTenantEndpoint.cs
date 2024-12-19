using Carter;
using Catalog.Database.Dtos;

using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;


namespace Catalog.Features.CreateTenant
{
    public record CreateTenantRequest(TenantDto Tenant);
    public record CreateTenantResponse(Guid Id);
    public class CreateTenantEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
          app.MapPost("/tenants", async (CreateTenantRequest request, ISender sender) =>
            {
               
                TenantDto tenant = new TenantDto(request.Tenant.TenantName, request.Tenant.TenantCD, request.Tenant.Description,request.Tenant.StartDate,request.Tenant.EndDate,request.Tenant.LicenseId,request.Tenant.Active);
                CreateTenantCommand command = new CreateTenantCommand(tenant);
                
                var result = await sender.Send(command);
                CreateTenantResponse response = new CreateTenantResponse(result.Id);
                

                return Results.Created($"/tenants/{response.Id}", response);
            })
            .WithName("CreateTenant")
            .Produces<CreateTenantResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Tenant")
            .WithDescription("Create Tenant");
        }
    }
}
