using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    /// <summary>
    ///     Classe de base pour les vue-modèles s'inserrant dans le pattern de navigation.
    /// </summary>
    public abstract class ViewModelNavigable : ObservableObject, IViewModel
    {
        #region Fields

        private object _Header;

        protected Navigator Navigator;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient un objet pour représenter l'en-tête du vue-modèle.
        /// </summary>
        public object Header
        {
            get => _Header;
            protected set => SetProperty(nameof(Header), ref _Header, value);
        }

        #endregion

        #region Constructor

        public ViewModelNavigable(Navigator navigator)
        {
            Navigator = navigator;
        }

        #endregion

    }
}
