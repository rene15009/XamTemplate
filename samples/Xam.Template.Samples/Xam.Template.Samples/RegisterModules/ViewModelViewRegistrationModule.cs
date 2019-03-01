using System.Linq;
using System.Reflection;
using Autofac;
using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xam.Template.Samples.ViewModels;
using Xam.Template.Samples.ViewModels.Controls;
using Module = Autofac.Module;

namespace Xam.Template.Samples.RegisterModules
{
    public class ViewModelViewRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
         
            //TODO: Fix assembly scan. It doesn't work.
            var asm = Assembly.GetExecutingAssembly();
            builder
                .RegisterAssemblyTypes(asm)
                .Where(t => typeof(ViewModelBase).IsAssignableFrom(t))
                .AssignableTo<IViewModelBase>();



            //builder.RegisterType<MenuViewModel>();
            //builder.RegisterType<AboutViewModel>();
            //builder.RegisterType<ItemsViewModel>();
            //builder.RegisterType<ItemDetailViewModel>();
            //builder.RegisterType<NewItemViewModel>();


        }
    }
}
