using Catalog.Database;
using Catalog.Database.Dtos;
using Catalog.Entities;
using Shared.CQRS;

namespace Catalog.Features.CreateTenant
{
    public record CreateTenantCommand(TenantDto Tenant)
    : ICommand<CreateTenantResult>;
    public record CreateTenantResult(Guid Id);
    internal class CreateTenantHandler
                (CatalogContext dbContext)
        : ICommandHandler<CreateTenantCommand, CreateTenantResult>
    {
        public async Task<CreateTenantResult> Handle(CreateTenantCommand command, CancellationToken cancellationToken)
        {
            var tenant = CreateNewTenant(command.Tenant);
            dbContext.Tenant.Add(tenant);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new CreateTenantResult(tenant.Id);
        }

        private Tenant  CreateNewTenant(TenantDto tenantDto)
        {
            var tenant = Tenant.Create(
                Guid.NewGuid(),
                tenantDto.TenantName,
                tenantDto.TenantCD,
                tenantDto.Description,
                tenantDto.StartDate,
                tenantDto.EndDate,
                tenantDto.LicenseId,
                tenantDto.Active
                
                );

            return tenant;
        }
    }
}
