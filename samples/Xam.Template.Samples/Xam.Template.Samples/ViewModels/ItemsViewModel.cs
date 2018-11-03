﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Xam.Template.Samples.Models;
using Xam.Template.Samples.Services;
using Xam.Template.Samples.Views;

namespace Xam.Template.Samples.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private readonly IMockDataStore _dataStore;
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel(IMockDataStore dataStore)
        {
            _dataStore = dataStore;
            Title = "Browse";
            Items = new ObservableCollection<Item>();

            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ////MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            ////{
            ////    var newItem = item as Item;
            ////    Items.Add(newItem);
            ////    await _dataStore.AddItemAsync(newItem);
            ////});

            var res= _dataStore.GetItemsAsync().GetAwaiter().GetResult();
            foreach (var v in res)
            {
                Items.Add(v);
            }

            

      //      ExecuteLoadItemsCommand();
        }

        async Task ExecuteLoadItemsCommand()
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