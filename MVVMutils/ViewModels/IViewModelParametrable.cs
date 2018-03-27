using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    public interface IViewModelParametrable : IViewModel
    {
        void setParameter(object parameter);
    }
}
