using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    public abstract class ViewModelDbAware<T> : ViewModelNavigable
        where T : DbContext
    {
        #region Fields

        private T _Context;

        #endregion

        #region Properties

        public T Context
        {
            get { return _Context; }
            set { SetProperty<T>(nameof(Context), ref _Context, value); }
        }

        #endregion

        #region Constructors

        public ViewModelDbAware(Navigator navigator, T context) : base(navigator)
        {
            Context = context;
        }

        #endregion
    }
}
