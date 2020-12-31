[assembly: WebActivator.PostApplicationStartMethod(typeof(FD.Videolocadora.Api.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace FD.Videolocadora.Api.App_Start
{
    using FD.Videolocadora.Api.Cache;
    using FD.Videolocadora.CrossCutting.IoC;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using System.Configuration;
    using System.Web.Http;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

        }

        private static void InitializeContainer(Container container)
        {

            if (ConfigurationManager.AppSettings["CACHE"] == "REDIS")
            {
                container.Register<ICache, RedisService>(Lifestyle.Scoped);
            }
            else
            {
                container.Register<ICache, MemoryCacheService>(Lifestyle.Scoped);
            }


            BootStrapper.RegisterServices(container);


            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
        }
    }
}