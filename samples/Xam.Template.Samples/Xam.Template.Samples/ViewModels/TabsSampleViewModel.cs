using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rene.Xam.Extensions.Base;
using Rene.Xam.Extensions.Bootstrapping.ViewContracts;
using Xam.Template.Samples.ViewModels.TabsSampleContent;

namespace Xam.Template.Samples.ViewModels
{
    public class TabsSampleViewModel : ViewModelBase, ITabbedViewModel, IViewEvents
    {
        public IList<IViewModelBase> TabsViewModels { get; set; }


        public void ViewLoad()
        {
            if (TabsViewModels != null)
                Console.Write(TabsViewModels.Count);
        }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;

            if (TabsViewModels != null)
            {
                var tabViewModel = TabsViewModels.FirstOrDefault(w => w.GetType() == typeof(Tab1PageViewModel));
                if (tabViewModel is Tab1PageViewModel tab1PageViewModel)
                {
                    tab1PageViewModel.Texto = $"Set From Parent View Model {newTitle}";
                }
            }
            
        }
    }
}
