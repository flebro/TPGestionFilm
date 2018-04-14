using DataLib;
using Microsoft.Win32;
using MVVMutils.Core;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPGestionFilm.Services;

namespace TPGestionFilm.ViewModels
{
    /// <summary>
    /// Vue gérant un film
    /// </summary>
    public class ViewModelMovie : ViewModelEdition<GestionFilmEntities, Movie>
    {
        #region Fields

        private IMoviePlayer _Player;

        private ReadOnlyCollection<Genre> _Genres;

        #region Commands

        private DelegateCommand _WatchCommand;

        private DelegateCommand _SelectFileCommand;

        private DelegateCommand _SelectPosterCommand;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Obtient la liste des genres de film
        /// </summary>
        public ReadOnlyCollection<Genre> Genres
        {
            get { return _Genres; }
            private set { SetProperty(nameof(Genre), ref _Genres, value); }
        }

        #region Commands

        /// <summary>
        /// Commande pour demander la lecture d'un film
        /// </summary>
        public DelegateCommand WatchCommand
        {
            get { return _WatchCommand; }
            private set { SetProperty(nameof(WatchCommand), ref _WatchCommand, value); }
        }

        /// <summary>
        /// Commande pour la sélection d'un fichier de film
        /// </summary>
        public DelegateCommand SelectFileCommand
        {
            get { return _SelectFileCommand; }
            private set { SetProperty(nameof(SelectFileCommand), ref _SelectFileCommand, value); }
        }

        /// <summary>
        /// Commande pour la sélection d'un image de film
        /// </summary>
        public DelegateCommand SelectPosterCommand
        {
            get { return _SelectPosterCommand; }
            private set { SetProperty(nameof(SelectPosterCommand), ref _SelectPosterCommand, value); }
        }

        #endregion

        #endregion

        #region Constructor

        public ViewModelMovie(Navigator navigator, GestionFilmEntities context, IMoviePlayer moviePlayer) : base(navigator, context)
        {
            _Player = moviePlayer;
            Genres = new ReadOnlyCollection<Genre>(Context.Genres.ToList());
            WatchCommand = new DelegateCommand(Watch_Execute, o => !InEditMode);
            SelectPosterCommand = new DelegateCommand(SelectPoster_Execute, o => InEditMode);
            SelectFileCommand = new DelegateCommand(SelectFile_Execute, o => InEditMode);
        }

        #endregion

        #region Methods

        #region WatchCommand

        public void Watch_Execute(object parameter)
        {
            _Player.startPlaying(Item);
        }

        #endregion

        #region SelectFileCommand

        public void SelectFile_Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Item.Data = openFileDialog.FileName;
            }
        }

        #endregion

        #region SelectPosterCommand

        public void SelectPoster_Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Item.Poster = openFileDialog.FileName;
            }
        }

        #endregion

        #region ViewModelEdition

        /// <summary>
        /// Vérifie si l'état du film en instance permet son enregistrement en base
        /// </summary>
        /// <param name="item">Film à valider</param>
        /// <returns>True si l'état du film en instance permet son enregistrement en base, sinon false</returns>
        protected override bool IsValid(Movie item)
        {
            return item.Name != null &&
                item.Data != null &&
                item.Genre != null &&
                File.Exists(item.Data);
        }

        #endregion

        #endregion

    }
}
