using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xamarin.Forms;

namespace Xam.Template.Samples.ViewModels.Controls
{
    public class MenuViewModel : ViewModelBase
    {
        public ICommand Items_click { get; set; }
        public ICommand About_click { get; set; }

        public ICommand Tabs_click { get; set; }


        private readonly INavigationService _navigationService;
        public MenuViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Items_click= new Command(async () => await _navigationService.PushAsync<ItemsViewModel>());
            About_click = new Command(async () => await _navigationService.PushAsync<AboutViewModel>());
            Tabs_click = new Command(async () => await _navigationService.PushAsync<TabsSampleViewModel>());
        }


    }
}
