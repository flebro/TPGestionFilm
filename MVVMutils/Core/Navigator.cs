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
        #region Events

        public event EventHandler<NavigationAskedEventArgs> NavigationAsked;

        #endregion

        #region Fields

        private IViewModelLocator _ViewModelLocator;

        #endregion

        #region Constructor

        public Navigator(IViewModelLocator viewModelLocator)
        {
            _ViewModelLocator = viewModelLocator;
        }

        #endregion

        #region Methods

        public void Navigate<T>(IViewModel source, object parameter = null) where T : IViewModel
        {
            IViewModel viewModel = _ViewModelLocator.GetViewModel<T>(parameter);
            NavigationAsked(source, new NavigationAskedEventArgs(viewModel));
        }

        #endregion

        #region Inner Classes

        public class NavigationAskedEventArgs : EventArgs
        {
            public IViewModel ViewModel { get; private set; }

            public NavigationAskedEventArgs(IViewModel viewModel)
            {
                this.ViewModel = viewModel;
            }
        }

        #endregion

    }
}
