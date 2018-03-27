using MVVMutils.Core;
using MVVMutils.Navigation;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TPGestionFilm.ViewModels
{
    public class ViewModelShell : ViewModelShellBase
    {
        #region Fields
                        
        #region Commands

        private ICommand _NavigateHome;
        private ICommand _NavigateSettings;
        private ICommand _NavigateMovie;

        #endregion

        #endregion

        #region Properties

        #region Commands

        public ICommand NavigateHome
        {
            get { return _NavigateHome; }
            set { SetProperty(nameof(NavigateHome), ref _NavigateHome, value); }
        }

        public ICommand NavigateSettings
        {
            get { return _NavigateSettings; }
            set { SetProperty(nameof(NavigateSettings), ref _NavigateSettings, value); }
        }

        public ICommand NavigateMovie
        {
            get { return _NavigateMovie; }
            set { SetProperty(nameof(NavigateMovie), ref _NavigateMovie, value); }
        }

        #endregion

        #endregion

        #region Constructor

        public ViewModelShell(IViewModelBuilder viewModelBuilder) : base(viewModelBuilder)
        {
            InitCommands();
        }

        #endregion

        #region Private Methods

        private void InitCommands()
        {
            _NavigateHome = new DelegateCommand(Navigate_Execute<ViewModelMovieList>, Navigate_CanExecute<ViewModelMovieList>);
            _NavigateSettings = new DelegateCommand(Navigate_Execute<ViewModelGenreList>, Navigate_CanExecute<ViewModelGenreList>);
            _NavigateMovie = new DelegateCommand(Navigate_Execute<ViewModelMovie>, Navigate_CanExecute<ViewModelMovie>);
        }

        #endregion

    }
}
