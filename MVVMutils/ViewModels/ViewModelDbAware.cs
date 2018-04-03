using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMutils.ViewModels
{
    public abstract class ViewModelDbAware<T> : ViewModelBase
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

        public ViewModelDbAware(T context)
        {
            Context = context;
        }

        #endregion
    }
}
