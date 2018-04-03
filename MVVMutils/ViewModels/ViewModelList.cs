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

        #endregion

        #region Properties

        public ObservableCollection<U> ItemSource
        {
            get { return _ItemSource; }
            protected set { SetProperty(nameof(ItemSource), ref _ItemSource, value); }
        }

        #endregion

        #region Constructors

        public ViewModelList(T context) : base(context)
        {
            ItemSource = context.Set<U>().Local;
        }

        #endregion
    }
}
