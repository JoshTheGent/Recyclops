using Abp.AspNetCore.Mvc.ViewComponents;

namespace Recyclops.Web.Views
{
    public abstract class RecyclopsViewComponent : AbpViewComponent
    {
        protected RecyclopsViewComponent()
        {
            LocalizationSourceName = RecyclopsConsts.LocalizationSourceName;
        }
    }
}
