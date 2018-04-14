using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.Core
{
    /// <summary>
    /// Classe utilitaire gérant la navigation au sein de l'application
    /// </summary>
    public class Navigator
    {
        #region Events

        /// <summary>
        /// Cette évennement est levé quand l'application demande de naviguer vers une vue modèle.
        /// Devrait être écouté par la classe principale de l'application
        /// </summary>
        public event EventHandler<NavigationAskedEventArgs> NavigationAsked;

        #endregion

        #region Fields

        private IViewModelLocator _ViewModelLocator;

        #endregion

        #region Constructor

        public Navigator(IViewModelLocator viewModelLocator)
        {
            _ViewModelLocator = viewModelLocator;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Cette méthode permet d'éxécuter la navigation vers une vue modèle
        /// </summary>
        /// <typeparam name="T">Type de la vue modèle vers laquelle on souhaite naviguer</typeparam>
        /// <param name="source">Vue modèle source de la demande de navigation</param>
        /// <param name="parameter">Parametre optionnel à transmettre à la vue modèle cible</param>
        public void Navigate<T>(IViewModel source, object parameter = null) where T : IViewModel
        {
            IViewModel viewModel = _ViewModelLocator.GetViewModel<T>(parameter);
            if (viewModel is IViewModelParametrable parametrable)
            {
                parametrable.SetParameter(parameter);
            }
            NavigationAsked(source, new NavigationAskedEventArgs(viewModel));
        }

        #endregion

        #region Inner Classes

        /// <summary>
        /// Arguments de l'évennement de demande de navigation
        /// </summary>
        public class NavigationAskedEventArgs : EventArgs
        {
            public IViewModel ViewModel { get; private set; }

            public NavigationAskedEventArgs(IViewModel viewModel)
            {
                this.ViewModel = viewModel;
            }
        }

        #endregion

    }
}
