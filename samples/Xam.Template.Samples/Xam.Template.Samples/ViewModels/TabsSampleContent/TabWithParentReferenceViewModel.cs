using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;
using Xamarin.Forms;

namespace Xam.Template.Samples.ViewModels.TabsSampleContent
{
    public class TabWithParentReferenceViewModel : ViewModelBase, ITabbedChildTabViewModel
    {
        public IViewModelBase ParentViewModel { get; set; }

        public ICommand BtnChange { get; set; }

        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set => SetProperty(ref _inputText, value);
        }

        public TabWithParentReferenceViewModel()
        {
            BtnChange = new Command(OnBtnChange);
        }

        

        private void OnBtnChange()
        {

            var tabed=ParentViewModel as TabsSampleViewModel;

            tabed?.ChangeTitle(InputText);
        }
    }
}
