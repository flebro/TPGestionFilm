using DataLib;
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

        #endregion

        #region Properties

        public ObservableCollection<Movie> FilteredItemSource
        {
            get { return _FilteredItemSource; }
            set { SetProperty(nameof(FilteredItemSource), ref _FilteredItemSource, value); }
        }

        #endregion

        #region Constructors

        public ViewModelMovieList(GestionFilmDMEntities context) : base(context)
        {

        }

        #endregion

    }
}
