using DataLib;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionFilm.ViewModels
{
    public class ViewModelMovie : ViewModelBase
    {
        #region Fields

        private Movie _Selected;

        #endregion

        #region Properties

        public Movie Selected
        {
            get { return _Selected; }
            set { _Selected = value; }
        }

        #endregion

    }
}
