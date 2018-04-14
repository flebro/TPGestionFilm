using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    /// <summary>
    /// Base pour la gestion d'une liste de modèles en base
    /// </summary>
    /// <typeparam name="T">Type du contexte de données</typeparam>
    /// <typeparam name="U">Type du modèle</typeparam>
    public class ViewModelList<T, U> : ViewModelDbAware<T>
        where T : DbContext
        where U : ObservableObject
    {
        #region Fields

        private ObservableCollection<U> _ItemSource;

        #endregion

        #region Properties

        /// <summary>
        /// Liste des modèles
        /// </summary>
        public ObservableCollection<U> ItemSource
        {
            get { return _ItemSource; }
            protected set { SetProperty(nameof(ItemSource), ref _ItemSource, value); }
        }

        #endregion

        #region Constructors

        public ViewModelList(Navigator navigator, T context) : base(navigator, context)
        {
            DbSet<U> items = context.Set<U>();
            items.Load();
            ItemSource = items.Local;
        }

        #endregion

    }
}
