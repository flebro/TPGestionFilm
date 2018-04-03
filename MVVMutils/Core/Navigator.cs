using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.Core
{
    public class Navigator
    {
        public event EventHandler<NavigationAskedEventArgs<>> NavigationAsked;
        
        public void Navigate<T>(IViewModel source, object parameter) where T : IViewModel
        {
            NavigationAsked(source, new NavigationAskedEventArgs<T>(parameter));
        }

        public class NavigationAskedEventArgs<T> : EventArgs
        {
            public object Parameter { get; private set; }

            public NavigationAskedEventArgs(object parameter)
            {
                this.Parameter = parameter;
            }
        }

    }
}
