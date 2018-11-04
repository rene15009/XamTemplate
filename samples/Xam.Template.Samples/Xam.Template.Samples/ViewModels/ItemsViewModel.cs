using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Xam.Template.Samples.Models;
using Xam.Template.Samples.Services;
using Xamarin.Forms;

namespace Xam.Template.Samples.ViewModels
{
    public class ItemsViewModel : ViewModelBase
    {
    
        private readonly IMockDataStore _dataStore;
        private readonly INavigationService _navigationService;


        public ObservableCollection<Item> Items { get; set; }=new ObservableCollection<Item>();
        public Command LoadItemsCommand { get; set; }

        public ICommand AddClick { get; set; }

        
        public ItemsViewModel(IMockDataStore dataStore,INavigationService navigationService)
        {
           _dataStore = dataStore;
            _navigationService = navigationService;

            //avoid await/async
            LoadItems().GetAwaiter().GetResult();

            AddClick=new Command(OnAddClick);
    
        }

        private void OnAddClick()
        {
          //  MessagingCenter
        }

        async Task LoadItems()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _dataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
