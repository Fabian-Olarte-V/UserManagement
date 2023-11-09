using Autofac;
using Prueba.Api.Services;
using Prueba.Data.Repositories.PersonRepository;
using Prueba.Data.Repositories.UserRepository;

namespace Prueba.Api.Infrastructure.AutofactModules;

public class InfrastructureModule : Module
{

    protected override void Load(ContainerBuilder builder)
    {
        builder.Register(ctx => new HttpClient())
            .SingleInstance();

        builder.RegisterType<UserRepository>()
            .As<IUserRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<PersonRepository>()
            .As<IPersonRepository>()
            .InstancePerLifetimeScope();

        builder.RegisterType<UserAccountService>()
            .As<IUserAccountService>()
            .InstancePerLifetimeScope();
    }
}