using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    /// <summary>
    /// Base pour une vue modèle gérant l'édition d'un model en base
    /// </summary>
    /// <typeparam name="T">Type du cotnexte de données</typeparam>
    /// <typeparam name="U">Type de modèle éditable</typeparam>
    public abstract class ViewModelEdition<T, U> : ViewModelDbAware<T>, IViewModelParametrable
        where T : DbContext
        where U : ObservableObject, new()
    {
        #region Fields

        private U _Item;
        private bool _InEditMode;
        private bool _Creation;

        #region Commands

        private DelegateCommand _StartEditCommand;

        private DelegateCommand _SaveCommand;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Instance de modèle édité
        /// </summary>
        public U Item
        {
            get { return _Item; }
            private set { SetProperty(nameof(Item), ref _Item, value); }
        }

        /// <summary>
        /// Indique si la vue modèle est en cours d'édition du modèle ou non
        /// </summary>
        public bool InEditMode
        {
            get { return _InEditMode; }
            private set { SetProperty(nameof(InEditMode), ref _InEditMode, value); }
        }

        #region Commands

        /// <summary>
        /// Commande pour débuter l'édition du modèle en instance
        /// </summary>
        public DelegateCommand StartEditCommand
        {
            get { return _StartEditCommand; }
            private set { SetProperty(nameof(StartEditCommand), ref _StartEditCommand, value); }
        }

        /// <summary>
        /// Commande pour sauvegarder le modèle en instance
        /// </summary>
        public DelegateCommand SaveCommand
        {
            get { return _SaveCommand; }
            set { SetProperty(nameof(SaveCommand), ref _SaveCommand, value); }
        }

        #endregion

        #endregion

        #region Constructor

        public ViewModelEdition(Navigator navigator, T context) : base(navigator, context)
        {
            StartEditCommand = new DelegateCommand(o=> InEditMode = true, o => !InEditMode);
            SaveCommand = new DelegateCommand(Save_Execute, Save_CanExecute);
        }

        #endregion

        #region Methods

        #region IViewModelParametrable

        /// <summary>
        /// Implementation d'une vue modèle paramétrable.
        /// Ici on passe le modèle à éditer (et non dans le constructeur afin de faciliter l'injection).
        /// </summary>
        /// <param name="parameter"></param>
        public void SetParameter(object parameter)
        {
            if (parameter != null && parameter is int id)
            {
                Item = Context.Set<U>().Find(id);
                Context.Entry(Item).State = EntityState.Detached;
            }
            else
            {
                Item = new U();
                InEditMode = true;
                _Creation = true;
            }
        }

        #endregion

        #region SaveCommand

        private void Save_Execute(object parameter)
        {
            Context.Entry<U>(Item).State = _Creation ?
                EntityState.Added :
                EntityState.Modified;
            Context.SaveChanges();
            InEditMode = false;
        }

        private bool Save_CanExecute(object parameter)
        {
            return InEditMode && IsValid(Item);
        }

        #endregion

        #region Abstracts

        /// <summary>
        /// Vérifie si l'état du modèle en instance permet son enregistrement en base
        /// </summary>
        /// <param name="item">Modèle à valider</param>
        /// <returns>True si l'état du modèle en instance permet son enregistrement en base, sinon false</returns>
        protected abstract bool IsValid(U item);

        #endregion

        #endregion

    }
}
