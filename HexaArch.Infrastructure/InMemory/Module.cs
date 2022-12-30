using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaArch.Infrastructure.InMemory
{
    public class Module: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Context>()
                .As<Context>()
                .SingleInstance();

            //
            // Register all Types in InMemoryDataAccess namespace
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace is not null && type.Namespace.Contains("InMemory"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
