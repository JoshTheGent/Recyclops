using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Recyclops.Authorization;

namespace Recyclops
{
    [DependsOn(
        typeof(RecyclopsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class RecyclopsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<RecyclopsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(RecyclopsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
