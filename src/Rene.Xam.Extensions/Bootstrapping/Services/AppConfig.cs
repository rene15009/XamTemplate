using System;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xamarin.Forms;

namespace Rene.Xam.Extensions.Bootstrapping.Services
{
    public class AppConfig : IAppConfig
    {
        private readonly Bootstrapper _bootstrapper;
        private readonly Application _application;

        
        public Page MainPage => _application?.MainPage;
        public bool IsUsingMasterDetailMode => _application?.MainPage is MasterDetailPage;
        public Func<string, string> ViewLocatorConvention => _bootstrapper.ViewLocatorConvention;
        public Func<string, string> TabViewModelLocatorConvention => _bootstrapper.TabViewModelLocatorConvention;


        public void ShowHideMenu(bool show)
        {
            if (IsUsingMasterDetailMode)
            {
                ((MasterDetailPage) MainPage).IsPresented = show;
            }
        }     


        internal AppConfig(Bootstrapper bootstrapper,Application application)
        {
            _bootstrapper = bootstrapper;
            _application = application;
        }
    }
}