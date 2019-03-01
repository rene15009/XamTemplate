using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rene.Xam.Extensions.Bootstrapping.BootstrapperInterfaces
{
    public interface IDependencyService
    {
        T Get<T>() where T : class;
    }
}
