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
    public class ViewModelMovieList : ViewModelList<GestionFilmDMEntities, Movie>
    {
        #region Fields

        private ObservableCollection<Movie> _FilteredItemSource;

        private string _SearchedText;

        private Movie _SelectedMovie;

        #endregion

        #region Properties

        public ObservableCollection<Movie> FilteredItemSource
        {
            get { return _FilteredItemSource; }
            set { SetProperty(nameof(FilteredItemSource), ref _FilteredItemSource, value); }
        }

        public string SearchedText
        {
            get { return _SearchedText; }
            set { SetProperty(nameof(SearchedText), ref _SearchedText, value); }
        }

        public Movie SelectedMovie
        {
            get { return _SelectedMovie; }
            set { SetProperty(nameof(SelectedMovie), ref _SelectedMovie, value); }
        }

        #endregion

        #region Constructors

        public ViewModelMovieList(Navigator navigator, GestionFilmDMEntities context) : base(navigator, context)
        {
            this.PropertyChanged += ViewModelMovieList_PropertyChanged;
        }

        #endregion

        #region Methods

        private void DoFilter()
        {
            FilteredItemSource.Clear();
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
        #endregion

        #region EventListener

        private void ViewModelMovieList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SearchedText))
            {
                DoFilter();
            }
            else if(e.PropertyName == nameof(SelectedMovie) && SelectedMovie != null)
            {
                Navigator.Navigate<ViewModelMovie>(this, SelectedMovie);
            }
        }

        #endregion
    }
}
