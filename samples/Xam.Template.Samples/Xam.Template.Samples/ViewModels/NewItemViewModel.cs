using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rene.Xam.Extensions.Base;
using Xam.Template.Samples.Models;

namespace Xam.Template.Samples.ViewModels
{
    public class NewItemViewModel : ViewModelBase
    {
        public Item Item { get; set; }

        public NewItemViewModel()
        {
        }
    }
}
