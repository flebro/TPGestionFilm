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
    /// Base pour une vue modèle pouvant communiquer avec la base de donnée
    /// </summary>
    /// <typeparam name="T">Type du contexte de données</typeparam>
    public abstract class ViewModelDbAware<T> : ViewModelNavigable
        where T : DbContext
    {
        #region Fields

        private T _Context;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient le contexte de données
        /// </summary>
        public T Context
        {
            get { return _Context; }
            private set { SetProperty<T>(nameof(Context), ref _Context, value); }
        }

        #endregion

        #region Constructors

        public ViewModelDbAware(Navigator navigator, T context) : base(navigator)
        {
            Context = context;
        }

        #endregion
    }
}
