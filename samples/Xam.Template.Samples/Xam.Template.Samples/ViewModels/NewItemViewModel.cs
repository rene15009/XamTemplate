using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xam.Template.Samples.Models;
using Xamarin.Forms;

namespace Xam.Template.Samples.ViewModels
{
    public class NewItemViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;


        public Item Item { get; set; } = new Item();

        public ICommand BtnSaveClick { get; set; }

        public NewItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            BtnSaveClick=new Command(OnSave);
        }

        private void OnSave()
        {
            
        }
    }
}
