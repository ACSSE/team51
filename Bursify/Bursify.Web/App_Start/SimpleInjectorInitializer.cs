using System.Web.Http;
using Bursify.Api.Administrators;
using Bursify.Api.Security;
using Bursify.Api.Sponsors;
using Bursify.Api.Students;
using Bursify.Api.Users;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using Bursify.Web;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.WebApi;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]

namespace Bursify.Web
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container)
        {
            //Api's
            container.Register<UserApi>();
            container.Register<MembershipApi>();
            container.Register<StudentApi>();
            container.Register<SponsorApi>();
            container.Register<AdminApi>();

            //Persistence
            container.Register(typeof(Repository<>));
            container.Register<SponsorRepository>();
            container.Register<BursifyUserRepository>();
            container.Register<CampaignRepository>();
            container.Register<SponsorshipRepository>();
            container.Register<AccountRepository>();
            container.Register<InstitutionRepository>();
            container.Register<SubjectRepository>();
            container.Register<StudentRepository>();
            container.Register<CampaignReportRepository>();
            container.Register(typeof(BridgeRepository<>));
            container.Register<CampaignSponsorRepository>();
            container.Register<StudentSponsorshipRepository>();
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>(Lifestyle.Scoped);
            container.Register<DataSession>(new WebRequestLifestyle(true));

            //Other
            container.Register<ICryptoService, CryptoService>(Lifestyle.Scoped);

        }
    }
}