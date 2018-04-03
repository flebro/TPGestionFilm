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
    public class ViewModelList<T, U> : ViewModelDbAware<T>
        where T : DbContext
        where U : ObservableObject
    {
        #region Fields

        private ObservableCollection<U> _ItemSource;

        #region Commands

        private DelegateCommand _DeleteCommand;

        #endregion

        #endregion

        #region Properties

        public ObservableCollection<U> ItemSource
        {
            get { return _ItemSource; }
            protected set { SetProperty(nameof(ItemSource), ref _ItemSource, value); }
        }

        #region Commands

        public DelegateCommand DeleteCommand
        {
            get { return _DeleteCommand; }
            set { _DeleteCommand = value; }
        }

        #endregion

        #endregion

        #region Constructors

        public ViewModelList(Navigator navigator, T context) : base(navigator, context)
        {
            ItemSource = context.Set<U>().Local;
        }

        #endregion

        #region Methods

        #region DeleteCommand

        protected void Delete_Execute(object parameter)
        {

        }

        protected bool Delete_CanExecute(object parameter)
        {
            return true;
        }

        #endregion

        #endregion
    }
}
