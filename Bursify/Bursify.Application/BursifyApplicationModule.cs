using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace Bursify
{
    [DependsOn(typeof(BursifyCoreModule), typeof(AbpAutoMapperModule))]
    public class BursifyApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
