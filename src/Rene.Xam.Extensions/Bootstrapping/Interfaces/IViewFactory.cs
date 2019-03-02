using System;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.Interfaces
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel : class, IViewModelBase where TView : Page;
        void Register(Type viewType, Type viewModelType);


        Page Resolve<TViewModel>() where TViewModel : class, IViewModelBase;
        Page Resolve<TViewModel, TKArguments>(TKArguments args) where TViewModel : class, IArgumentViewModel<TKArguments>;
        Page Resolve(Type viewModelType);
        Page Resolve<TKArguments>(Type viewModelType, TKArguments args);

    }
}
