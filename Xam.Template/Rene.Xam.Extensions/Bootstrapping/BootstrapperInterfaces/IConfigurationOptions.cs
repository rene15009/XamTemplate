using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.BootstrapperInterfaces
{
    public interface IConfigurationOptions
    {
        void SetStartupView<TViewModel>() where TViewModel : IViewModelBase;

        void UseMasterDetailMode<TMenuViewModel>() where TMenuViewModel : IViewModelBase;


        void UseMasterDetailMode<TMenuViewModel, TDetailViewModel>()
            where TMenuViewModel : IViewModelBase
            where TDetailViewModel : IViewModelBase;


        void SetStartupView(Page pageInstance);


    }
}