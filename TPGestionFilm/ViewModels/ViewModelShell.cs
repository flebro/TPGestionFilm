using MVVMutils.Core;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TPGestionFilm.ViewModels
{
    /// <summary>
    /// View model pour l'interfaec principale, le "shell"
    /// </summary>
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

        /// <summary>
        /// Commande de navigation vers l'accueil
        /// </summary>
        public ICommand NavigateHome
        {
            get { return _NavigateHome; }
            set { SetProperty(nameof(NavigateHome), ref _NavigateHome, value); }
        }

        /// <summary>
        /// Commande de navigation vers l'écran de paramétrage
        /// </summary>
        public ICommand NavigateSettings
        {
            get { return _NavigateSettings; }
            set { SetProperty(nameof(NavigateSettings), ref _NavigateSettings, value); }
        }

        /// <summary>
        /// Commande de navigation vers une fiche film
        /// </summary>
        public ICommand NavigateMovie
        {
            get { return _NavigateMovie; }
            set { SetProperty(nameof(NavigateMovie), ref _NavigateMovie, value); }
        }

        #endregion

        #endregion

        #region Constructor

        public ViewModelShell(Navigator navigator, ViewModelMovieList home) : base(navigator)
        {
            DisplayedView = home;
            InitCommands();
        }

        #endregion

        #region Private Methods

        private void InitCommands()
        {
            _NavigateHome = CreateDefaultNavigateCommand<ViewModelMovieList>();
            _NavigateSettings = CreateDefaultNavigateCommand<ViewModelGenreList>();
            _NavigateMovie = CreateDefaultNavigateCommand<ViewModelMovie>();
        }

        #endregion

    }
}
