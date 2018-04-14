using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    /// <summary>
    /// Base pour la gestion d'une liste de modèles en base gérant la sélection
    /// </summary>
    /// <typeparam name="T">Type du contexte de données</typeparam>
    /// <typeparam name="U">Type du modèle</typeparam>
    public abstract class ViewModelListSelectable<T, U> : ViewModelList<T, U>
        where T : DbContext
        where U : ObservableObject
    {
        #region Fields

        private U _SelectedItem;

        #endregion

        #region Properties

        /// <summary>
        /// Instance de modèle selectionné
        /// </summary>
        public U SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(nameof(SelectedItem), ref _SelectedItem, value); }
        }

        #endregion

        #region Constructor

        public ViewModelListSelectable(Navigator navigator, T context) : base(navigator, context) { }

        #endregion

    }
}
