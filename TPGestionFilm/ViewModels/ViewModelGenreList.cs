using DataLib;
using MVVMutils.Core;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionFilm.ViewModels
{
    public class ViewModelGenreList : ViewModelList<GestionFilmEntities, Genre>
    {
        #region Constructors

        public ViewModelGenreList(Navigator navigator, GestionFilmEntities context) : base(navigator, context)
        {
        }

        #endregion

    }
}
