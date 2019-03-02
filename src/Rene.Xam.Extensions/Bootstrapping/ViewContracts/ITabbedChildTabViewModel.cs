using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rene.Xam.Extensions.Bootstrapping.ViewContracts
{
    public interface ITabbedChildTabViewModel
    {
        IViewModelBase ParentViewModel { get; set; }
    }
}
