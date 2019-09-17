using System.Threading.Tasks;
using Recyclops.Configuration.Dto;

namespace Recyclops.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
