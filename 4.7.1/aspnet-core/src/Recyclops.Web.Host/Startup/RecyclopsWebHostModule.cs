using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Recyclops.Configuration;

namespace Recyclops.Web.Host.Startup
{
    [DependsOn(
       typeof(RecyclopsWebCoreModule))]
    public class RecyclopsWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public RecyclopsWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RecyclopsWebHostModule).GetAssembly());
        }
    }
}
