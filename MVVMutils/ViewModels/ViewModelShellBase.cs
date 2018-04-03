using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    public abstract class ViewModelShellBase : ViewModelBase
    {

        #region Fields

        private IViewModelLocator _Locator;
        private IViewModel _DisplayedView;

        #endregion

        #region Properties

        public IViewModel DisplayedView
        {
            get { return _DisplayedView; }
            set { SetProperty(nameof(DisplayedView), ref _DisplayedView, value); }
        }

        #endregion

        #region Constructors

        public ViewModelShellBase(IViewModelLocator locator)
        {
            _Locator = locator;
        }

        #endregion

        #region Methods

        #region Generic Commands

        protected void DefaultNavigate_Execute<T>(object parameter) where T : IViewModel
        {
            IViewModel viewModel = _Locator.GetViewModel<T>(parameter);
            if (viewModel is IViewModelParametrable parametrable)
            {
                parametrable.setParameter(parameter);
            }
            DisplayedView = viewModel;
        }

        protected bool DefaultNavigate_CanExecute<T>(object parameter) where T : IViewModel
        {
            return !(DisplayedView is T);
        }

        protected DelegateCommand CreateDefaultNavigateCommand<T>() where T : IViewModel
        {
            return new DelegateCommand(DefaultNavigate_Execute<T>, DefaultNavigate_CanExecute<T>);
        }

        #endregion

        #endregion

    }
}
