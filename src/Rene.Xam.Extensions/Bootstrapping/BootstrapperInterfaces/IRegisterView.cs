using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.BootstrapperInterfaces
{
    public interface IRegisterView
    {
        void RegisterView<TView, TViewModel>() where TViewModel : class, IViewModelBase where TView : Page;
    }
}