

using Autofac;
using AutoMapper;
using System.Collections.Generic;

namespace RestService.Domain
{
    public class DomainMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register all profile classes in the calling assembly
            builder.RegisterAssemblyTypes(typeof(DomainMapper).Assembly).As<Profile>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                foreach (var profile in context.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();
        }
    }
}
