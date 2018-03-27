using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    public class ViewModelEdition<T> : ViewModelBase, IViewModelParametrable
        where T : ObservableObject, new()
    {
        #region Fields

        private T _Edited;

        #endregion

        #region Properties

        public T Edited
        {
            get { return _Edited; }
            set { SetProperty(nameof(Edited), ref _Edited, value); }
        }

        #endregion

        #region IViewModelParametrable

        public void setParameter(object parameter)
        {
            if (parameter != null && parameter is T edited)
            {
                Edited = edited;
            } else
            {
                Edited = new T();
            }

        }

        #endregion
        
    }
}
