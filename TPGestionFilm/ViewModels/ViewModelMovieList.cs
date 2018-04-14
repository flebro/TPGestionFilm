using DataLib;
using MVVMutils.Core;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionFilm.ViewModels
{
    /// <summary>
    /// Vue modèle gérant une liste de film
    /// </summary>
    public class ViewModelMovieList : ViewModelList<GestionFilmEntities, Movie>
    {
        #region Fields

        private ObservableCollection<Movie> _FilteredItemSource;

        private string _SearchedText;

        private Dictionary<Genre, List<Movie>> _GenreDictionnary;

        #region Commands

        private DelegateCommand _SelectionCommand;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Liste des films visible après application du filtre de recherche en instance
        /// </summary>
        public ObservableCollection<Movie> FilteredItemSource
        {
            get { return _FilteredItemSource; }
            set { SetProperty(nameof(FilteredItemSource), ref _FilteredItemSource, value); }
        }

        /// <summary>
        /// Texte recherché
        /// </summary>
        public string SearchedText
        {
            get { return _SearchedText; }
            set { SetProperty(nameof(SearchedText), ref _SearchedText, value); }
        }

        /// <summary>
        /// Map des films classés par genre
        /// </summary>
        public Dictionary<Genre, List<Movie>> GenreDictionnary
        {
            get { return _GenreDictionnary; }
            set { SetProperty(nameof(GenreDictionnary), ref _GenreDictionnary, value); }
        }

        #region Commands

        /// <summary>
        /// Commande de sélection d'un film
        /// </summary>
        public DelegateCommand SelectionCommand
        {
            get { return _SelectionCommand; }
            set { SetProperty(nameof(SelectionCommand), ref _SelectionCommand, value); }
        }

        #endregion

        #endregion

        #region Constructors

        public ViewModelMovieList(Navigator navigator, GestionFilmEntities context) : base(navigator, context)
        {
            // Ecoute des évenements
            this.PropertyChanged += ViewModelMovieList_PropertyChanged;
            // Création commande
            SelectionCommand = new DelegateCommand(Selection_Execute);
            // Initialisation des données
            GenreDictionnary = ItemSource.GroupBy(m => m.Genre).ToDictionary(g => g.Key, g => g.ToList());
            DoFilter();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Applique la recherche en instance
        /// </summary>
        private void DoFilter()
        {
            if (SearchedText?.Length > 0)
            {
                string searchedText = SearchedText.ToLower();
                FilteredItemSource = new ObservableCollection<Movie>(ItemSource.Where(m => m.Name.ToLower().Contains(searchedText)));
            }
            else
            {
                FilteredItemSource = new ObservableCollection<Movie>(ItemSource);
            }
        }

        #region SelectionCommand

        private void Selection_Execute(object parameter)
        {
            if (parameter is Movie)
            {
                Navigator.Navigate<ViewModelMovie>(this, parameter);
            } else
            {
                throw new InvalidOperationException();
            }
        }

        #endregion

        #endregion

        #region EventListener

        /// <summary>
        /// Ici on écoute le changement du texte recherché pour mettre à jour la recherche automatiquement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewModelMovieList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchedText))
            {
                DoFilter();
            }
        }

        #endregion
    }
}
