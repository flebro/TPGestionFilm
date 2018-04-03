using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    public abstract class ViewModelShellBase : ViewModelNavigable
    {

        #region Fields

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

        public ViewModelShellBase(Navigator navigator) : base(navigator)
        {
            navigator.NavigationAsked += Navigator_NavigationAsked;
        }

        #endregion

        #region Methods

        #region Generic Commands

        protected void DefaultNavigate_Execute<T>(object parameter) where T : IViewModel
        {
            Navigator.Navigate<T>(this, parameter);
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

        #region EventListeners

        private void Navigator_NavigationAsked(object sender, Navigator.NavigationAskedEventArgs e)
        {
            DisplayedView = e.ViewModel;
        }

        #endregion

    }
}
