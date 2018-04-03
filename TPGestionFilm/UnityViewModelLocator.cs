using MVVMutils.Core;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace TPGestionFilm
{
    public class UnityViewModelLocator : IViewModelLocator
    {
        #region Fields

        private IUnityContainer _container;

        #endregion

        #region Constructors

        public UnityViewModelLocator(IUnityContainer container)
        {
            _container = container;
        }

        #endregion

        #region IViewModelLocator

        public IViewModel GetViewModel<T>(object parameter) where T : IViewModel
        {
            return _container.Resolve<T>();
        }

        #endregion

    }
}
