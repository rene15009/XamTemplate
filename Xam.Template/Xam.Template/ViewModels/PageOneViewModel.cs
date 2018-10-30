using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xamarin.Forms;

namespace Xam.Template.ViewModels
{


    public class PageOneViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public Command btnNavClick { get; set; }

        public PageOneViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
         //   PageOne_click = new Command(async () => await _navigationService.PushAsync<PageOneViewModel>());

            btnNavClick = new Command(async () => await _navigationService.PushAsync<PageTwoViewModel>());
         
        }
    }
}
