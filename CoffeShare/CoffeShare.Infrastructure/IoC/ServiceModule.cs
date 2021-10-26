using Autofac;
using CoffeeShare.Infrastructure.Services;
using System.Linq;
using System.Reflection;
using CoffeeShare.Infrastructure.Services.Interfaces;

namespace CoffeeShare.Infrastructure.IoC
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ServiceModule)
                .GetTypeInfo()
                .Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
