using System;
using Autofac;

namespace Rene.Xam.Extensions.Bootstrapping.BootstrapperInterfaces
{
    public interface IBootstrapper
    {

        IBootstrapper RegisterDependencies(Action<ContainerBuilder> actionToBuilder);

        IBootstrapper RegisterViews(Action<IRegisterView> register);

        IBootstrapper Configure(Action<IConfigurationOptions> config);

        void Build();
    }
}