using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace Recyclops.Web.Views
{
    public abstract class RecyclopsRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected RecyclopsRazorPage()
        {
            LocalizationSourceName = RecyclopsConsts.LocalizationSourceName;
        }
    }
}
