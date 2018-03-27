using MVVMutils.Navigation;
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

        private IViewModelBuilder _ViewModelBuilder;
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

        public ViewModelShellBase(IViewModelBuilder navigator)
        {
            _ViewModelBuilder = navigator;
        }

        #endregion

        #region Methods

        #region Generic Commands

        public void Navigate_Execute<T>(object parameter) where T : IViewModel
        {
            IViewModel viewModel = _ViewModelBuilder.GetViewModel<T>(parameter);
            if (viewModel is IViewModelParametrable parametrable)
            {
                parametrable.setParameter(parameter);
            }
            DisplayedView = viewModel;
        }

        public bool Navigate_CanExecute<T>(object parameter) where T : IViewModel
        {
            return !(DisplayedView is T);
        }

        #endregion

        #endregion

    }
}
