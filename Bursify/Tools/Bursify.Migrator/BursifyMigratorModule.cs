using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Bursify.EntityFramework;

namespace Bursify.Migrator
{
    [DependsOn(typeof(BursifyDataModule))]
    public class BursifyMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<BursifyDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}