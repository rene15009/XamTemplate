﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rene.Xam.Extensions.Base;

namespace Xam.Template.Samples.ViewModels.TabsSampleContent
{
    public class Tab1PageViewModel : ViewModelBase
    {
        private string _texto= "Welcome to Xamarin.Forms!";
        public string Texto
        {
            get => _texto;
            set => SetProperty(ref _texto, value);
        }
        
        public Tab1PageViewModel()
        {
            
        }
    }
}
