using Autofac;
using CoffeeShare.Infrastructure.Repositories;
using System.Linq;
using System.Reflection;
using CoffeeShare.Infrastructure.Repositories.Interfaces;

namespace CoffeeShare.Infrastructure.IoC
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
