using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.Core
{
    /// <summary>
    ///     Classe qui implémente <see cref="INotifyPropertyChanged"/> et <see cref="INotifyPropertyChanging"/>./>
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Events

        public event PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        ///     Affecte une valeur à un champ privé et déclenche les événements <see cref="PropertyChanged"/> et <see cref="PropertyChanging"/>.
        /// </summary>
        /// <typeparam name="T">Type du champ privé.</typeparam>
        /// <param name="propertyName">Nom de la propriété qui expose le champ privé.</param>
        /// <param name="obj">Référence sur le champ privé.</param>
        /// <param name="value">Valeur à affecter au champ privé.</param>
        protected void SetProperty<T>(string propertyName, ref T obj, T value)
        {
            if ((obj == null && value != null) || (obj != null && !obj.Equals(value)))
            {
                OnPropertyChanging(propertyName);
                obj = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected virtual void OnPropertyChanging(string propertyName)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
