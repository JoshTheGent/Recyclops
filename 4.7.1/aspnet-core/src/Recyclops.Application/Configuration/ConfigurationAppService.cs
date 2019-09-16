using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Recyclops.Configuration.Dto;

namespace Recyclops.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : RecyclopsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
