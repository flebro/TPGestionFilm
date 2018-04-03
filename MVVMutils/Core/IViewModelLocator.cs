using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.Core
{
    public interface IViewModelLocator
    {
        IViewModel GetViewModel<T>(object parameter) where T : IViewModel;
    }
}
