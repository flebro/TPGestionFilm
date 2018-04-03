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
    public class ViewModelMovie : ViewModelEdition<GestionFilmDMEntities, Movie>
    {
        #region Fields

        private IMoviePlayer _Player;

        private DelegateCommand _WatchCommand;

        public DelegateCommand WatchCommand
        {
            get { return _WatchCommand; }
            set { SetProperty(nameof(WatchCommand), ref _WatchCommand, value); }
        }

        #endregion

        #region Constructor

        public ViewModelMovie(GestionFilmDMEntities context, IMoviePlayer moviePlayer) : base(context)
        {
            _Player = moviePlayer;
            WatchCommand = new DelegateCommand(Watch_Execute, Watch_CanExecute);
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
