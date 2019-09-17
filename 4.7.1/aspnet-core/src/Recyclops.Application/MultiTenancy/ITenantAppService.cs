using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Recyclops.MultiTenancy.Dto;

namespace Recyclops.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

