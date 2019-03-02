using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Rene.Xam.Extensions.Bootstrapping.Interfaces;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;

namespace Rene.Xam.Extensions.Base
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModelBase
    {

        #region "Propiedades"
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _subtitle = string.Empty;
        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value);
        }

        private string _icon = string.Empty;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (SetProperty(ref _isBusy, value))
                    IsNotBusy = !_isBusy;
            }
        }

        private bool _isNotBusy = true;
        public bool IsNotBusy
        {
            get => _isNotBusy;
            set
            {
                if (SetProperty(ref _isNotBusy, value))
                    IsBusy = !_isNotBusy;
            }
        }

        private bool _canLoadMore = true;
        public bool CanLoadMore
        {
            get => _canLoadMore;
            set => SetProperty(ref _canLoadMore, value);
        }


        private string _header = string.Empty;
        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        private string _footer = string.Empty;
        public string Footer
        {
            get => _footer;
            set => SetProperty(ref _footer, value);
        }

        #endregion

        #region INotifyPropertyChanged

        protected bool SetProperty<T>(ref T backingStore, T value,
                 [CallerMemberName]string propertyName = "",
                 Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}
