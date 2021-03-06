﻿using System;
using Rene.Xam.Extensions.Base;
using Xam.Template.Samples.Models;

namespace Xam.Template.Samples.ViewModels
{
    public class ItemDetailViewModel : ViewModelBase
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
