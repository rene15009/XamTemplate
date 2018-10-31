using System;
using System.Threading.Tasks;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Lazy<INavigation> _navigation;
        private readonly IViewFactory _viewFactory;
        private readonly IAppConfig _appConfig;
        private INavigation Navigation => _navigation.Value;

        public NavigationService(Lazy<INavigation> navigation, IViewFactory viewFactory, IAppConfig appConfig)
        {
            _navigation = navigation;
            _viewFactory = viewFactory;
            _appConfig = appConfig;
        }

        public async Task PopAsync()
        {
            await Navigation.PopAsync();
        }

        public async Task PopToRootAsync()
        {
            await Navigation.PopToRootAsync();
        }

        public async Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase
        {

            var view = _viewFactory.Resolve<TViewModel>();

            if (_appConfig.IsUsingMasterDetailMode)
            {
                _appConfig.SetDetailPage(new NavigationPage(view));
                _appConfig.ShowHideMenu(false);
            }
            else
            {
                await Navigation.PushAsync(view);
            }

        }

        public async Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase
        {
            var view = _viewFactory.Resolve<TViewModel>();
            await Navigation.PushModalAsync(view);
        }
    }
}
