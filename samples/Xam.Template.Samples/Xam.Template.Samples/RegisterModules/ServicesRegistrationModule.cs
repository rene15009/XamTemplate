using Autofac;
using Xam.Template.Samples.Services;

namespace Xam.Template.Samples.RegisterModules
{
    public class ServicesRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MockDataStore>().As<IMockDataStore>();

            base.Load(builder);
        }

    }
}
