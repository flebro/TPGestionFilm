using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    /// <summary>
    /// Définition de base d'une vue modèle
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
    }
}
