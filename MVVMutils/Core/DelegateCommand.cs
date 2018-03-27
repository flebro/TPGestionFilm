using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMutils.Core
{
    /// <summary>
    ///     Représente une commande d'application.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        #region Events

        /// <summary>
        ///     Déclenché lorsque le CanExecute de la commande doit être évalué.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region Fields

        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="DelegateCommand"/> qui peut toujours s'exécuter.
        /// </summary>
        /// <param name="execute">Méthode à rappeler lors de l'exécution de la commande.</param>
        public DelegateCommand(Action<object> execute)
        {
            _Execute = execute;
            _CanExecute = new Func<object, bool> (o => true);
        }

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="DelegateCommand"/>.
        /// </summary>
        /// <param name="execute">Méthode à rappeler lors de l'exécution de la commande.</param>
        /// <param name="canExecute">Méthode à rappeler pour valider que la commande peut être exécutée.</param>
        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _Execute = execute;
            _CanExecute = canExecute;
        }

        #endregion

        #region Methods
        public bool CanExecute(object parameter) => _CanExecute != null ? _CanExecute(parameter) : true;

        public void Execute(object parameter) => _Execute(parameter);

        #endregion

    }
}
