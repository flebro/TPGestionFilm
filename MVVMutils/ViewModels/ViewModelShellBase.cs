using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    /// <summary>
    /// Clase de base pour une vue modèle principale d'application utilisant le pattern de navigation
    /// </summary>
    public abstract class ViewModelShellBase : ViewModelNavigable
    {
        #region Fields

        private IViewModel _DisplayedView;

        #endregion

        #region Properties

        /// <summary>
        /// Instance de vue modèle enfant en cours
        /// </summary>
        public IViewModel DisplayedView
        {
            get { return _DisplayedView; }
            set { SetProperty(nameof(DisplayedView), ref _DisplayedView, value); }
        }

        #endregion

        #region Constructors

        public ViewModelShellBase(Navigator navigator) : base(navigator)
        {
            navigator.NavigationAsked += Navigator_NavigationAsked;
        }

        #endregion

        #region Methods

        #region Generic Commands

        /// <summary>
        /// Méthode de base d'éxécution de demande de navigation
        /// </summary>
        /// <typeparam name="T">Vue modèle vers laquelle on souhaite naviguer</typeparam>
        /// <param name="parameter">Paramètre à transmettre à la vue modèle de destination</param>
        protected void DefaultNavigate_Execute<T>(object parameter) where T : IViewModel
        {
            Navigator.Navigate<T>(this, parameter);
        }

        /// <summary>
        /// Méthode de base pour vérifier la possitbilité d'éxécution de demande de navigation
        /// </summary>
        /// <typeparam name="T">Vue modèle vers laquelle on souhaite naviguer</typeparam>
        /// <param name="parameter">Paramètre optionnel</param>
        protected bool DefaultNavigate_CanExecute<T>(object parameter) where T : IViewModel
        {
            return !(DisplayedView is T);
        }

        /// <summary>
        /// Méthode utilitaire pour créer une commande de navigationutilisant le comportement par défaut
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected DelegateCommand CreateDefaultNavigateCommand<T>() where T : IViewModel
        {
            return new DelegateCommand(DefaultNavigate_Execute<T>, DefaultNavigate_CanExecute<T>);
        }

        #endregion

        #endregion

        #region EventListeners

        /// <summary>
        /// Comportement par défaut à la récéption d'une demande de navigation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Navigator_NavigationAsked(object sender, Navigator.NavigationAskedEventArgs e)
        {
            DisplayedView = e.ViewModel;
        }

        #endregion

    }
}
