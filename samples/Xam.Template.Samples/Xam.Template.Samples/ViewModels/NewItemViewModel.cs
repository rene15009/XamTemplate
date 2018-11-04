using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xam.Template.Samples.Models;

namespace Xam.Template.Samples.ViewModels
{
    public class NewItemViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public Item Item { get; set; } = new Item();

        public NewItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
