using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    /// <summary>
    /// Définit une vue modèle paramétrable
    /// </summary>
    public interface IViewModelParametrable : IViewModel
    {
        void SetParameter(object parameter);
    }
}
