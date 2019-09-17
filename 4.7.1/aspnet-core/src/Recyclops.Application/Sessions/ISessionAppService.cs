using System.Threading.Tasks;
using Abp.Application.Services;
using Recyclops.Sessions.Dto;

namespace Recyclops.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
