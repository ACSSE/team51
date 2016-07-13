using System.Reflection;
using System.Web.Mvc;
using Bursify.Api.Users;
using Bursify.App_Start;
using Bursify.Data.EF.Repositories;
using Bursify.Data.EF.Uow;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof (SimpleInjectorInitializer), "Initialize")]

namespace Bursify.App_Start
{
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            //Api's
            container.Register<UserApi>();
            
            //Persistence
            container.Register(typeof(Repository<>));
            //just changed this now
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>(new WebRequestLifestyle(true));
            container.Register<DataSession>(new WebRequestLifestyle(true));

            //Other
        }
    }
}