using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Recyclops.Controllers
{
    public abstract class RecyclopsControllerBase: AbpController
    {
        protected RecyclopsControllerBase()
        {
            LocalizationSourceName = RecyclopsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
