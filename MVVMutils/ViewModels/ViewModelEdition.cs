using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
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

        public U Item
        {
            get { return _Item; }
            private set { SetProperty(nameof(Item), ref _Item, value); }
        }

        public bool InEditMode
        {
            get { return _InEditMode; }
            private set { SetProperty(nameof(InEditMode), ref _InEditMode, value); }
        }

        #region Commands

        public DelegateCommand StartEditCommand
        {
            get { return _StartEditCommand; }
            private set { SetProperty(nameof(StartEditCommand), ref _StartEditCommand, value); }
        }

        public DelegateCommand SaveCommand
        {
            get { return _SaveCommand; }
            set { SetProperty(nameof(SaveCommand), ref _SaveCommand, value); }
        }

        #endregion

        #endregion

        #region Constructor

        public ViewModelEdition(T context) : base(context)
        {
            StartEditCommand = new DelegateCommand(o=> InEditMode = true, o => !InEditMode);
            SaveCommand = new DelegateCommand(Save_Execute, o => InEditMode);
        }

        #endregion

        #region Methods

        #region IViewModelParametrable

        public void setParameter(object parameter)
        {
            if (parameter != null && parameter is U item)
            {
                Item = item;
                Context.Entry(Item).State = EntityState.Detached;
            }
            else
            {
                Item = new U();
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
        }

        #endregion

        #endregion

    }
}
