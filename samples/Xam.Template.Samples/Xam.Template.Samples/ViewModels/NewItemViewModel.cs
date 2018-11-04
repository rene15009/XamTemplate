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
using Xam.Template.Samples.Services;
using Xamarin.Forms;

namespace Xam.Template.Samples.ViewModels
{
    public class NewItemViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IMockDataStore _dataStore;


        public Item Item { get; set; } = new Item();

        public ICommand BtnSaveClick { get; set; }

        public NewItemViewModel(INavigationService navigationService, IMockDataStore dataStore)
        {
            _navigationService = navigationService;
            _dataStore = dataStore;

            BtnSaveClick = new Command(OnSave);
        }

        private async void OnSave()
        {
            var i = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = $"Nombre ",
                Description = $"Description {DateTime.Now:G}"
            };
            await _dataStore.AddItemAsync(i);

            await _navigationService.PopAsync();
        }
    }
}
