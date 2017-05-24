using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Owin;
using RestService.Domain;
using RestService.EntityFramework;
using RestService.Repository.Repository.Base;
using RestService.Service.Services;
using RestService.WebApi.RequestIdentity;
using System;
using System.Reflection;
using System.Web.Http;

namespace RestService.WebApi
{
    public partial class Startup
    {
        public void ConfigureAutoFac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            // Register Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register up the Request Identity Provider
            builder.RegisterType<RequestIdentityProvider>().As<IRequestIdentityProvider>().InstancePerRequest();

            // Logging
            //builder.RegisterType<ILogger>().AsSelf().InstancePerRequest();

            // Register module for different layers
            builder.RegisterModule(new DtoMapperModule());
            builder.RegisterModule(new DomainMapperModule());

            // AutoMapper
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            //Register Generic Repository
            builder.RegisterGeneric(typeof(Repository<>))
                       .As(typeof(IRepository<>))
                       .InstancePerRequest();


            //Register Product Service
            builder.RegisterAssemblyTypes(assemblies)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces();
            //builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
            builder.RegisterType<DataContext>().InstancePerRequest();


            // Register method interceptor module
            //builder.RegisterModule(new InterceptModule());

            // Build and Resolve
            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;

            var resolver = new AutofacWebApiDependencyResolver(container);
            config.DependencyResolver = resolver;

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            app.UseAutofacWebApi(GlobalConfiguration.Configuration);
        }
    }
}