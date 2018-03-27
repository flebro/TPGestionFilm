using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
    }
}
