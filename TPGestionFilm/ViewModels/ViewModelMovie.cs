using DataLib;
using MVVMutils.Core;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPGestionFilm.Services;

namespace TPGestionFilm.ViewModels
{
    public class ViewModelMovie : ViewModelEdition<GestionFilmEntities, Movie>
    {
        #region Fields

        private IMoviePlayer _Player;
        
        private DelegateCommand _WatchCommand;

        private DelegateCommand _HomeCommand;

        #endregion

        #region Properties

        public DelegateCommand WatchCommand
        {
            get { return _WatchCommand; }
            private set { SetProperty(nameof(WatchCommand), ref _WatchCommand, value); }
        }

        public DelegateCommand HomeCommand
        {
            get { return _HomeCommand; }
            private set { SetProperty(nameof(HomeCommand), ref _HomeCommand, value); }
        }

        #endregion

        #region Constructor

        public ViewModelMovie(Navigator navigator, GestionFilmEntities context, IMoviePlayer moviePlayer) : base(navigator, context)
        {
            _Player = moviePlayer;
            WatchCommand = new DelegateCommand(Watch_Execute, Watch_CanExecute);
            HomeCommand = new DelegateCommand(o => Navigator.Navigate<ViewModelMovieList>(this));
        }

        #endregion

        #region Methods

        #region WatchCommand

        public void Watch_Execute(object parameter)
        {
            _Player.startPlaying(Item);
        }

        public bool Watch_CanExecute(object parameter)
        {
            return !InEditMode;
        }

        #endregion

        #endregion

    }
}
