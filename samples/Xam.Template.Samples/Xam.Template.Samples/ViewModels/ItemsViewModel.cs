using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;
using Rene.Xam.Extensions.Base;
using Xam.Template.Samples.Models;
using Xam.Template.Samples.Services;
using Xamarin.Forms;

namespace Xam.Template.Samples.ViewModels
{
    public class ItemsViewModel : ViewModelBase
    {
        private readonly IComponentContext _componentContext;
        private readonly IMockDataStore _dataStore;

        private string _texto;
        public string Texto
        {
            get => _texto;
            set => SetProperty(ref _texto, value);
        }


        public ObservableCollection<Item> Items { get; set; }=new ObservableCollection<Item>();
        public Command LoadItemsCommand { get; set; }

        
        public ItemsViewModel(IMockDataStore dataStore)
        {
           

           _dataStore = dataStore;

            LoadItems().GetAwaiter().GetResult();

            Texto = $"{Items?.Count} Items";
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
