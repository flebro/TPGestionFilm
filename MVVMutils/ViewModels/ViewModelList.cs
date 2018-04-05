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

        private U _SelectedItem;

        #endregion

        #region Properties

        public ObservableCollection<U> ItemSource
        {
            get { return _ItemSource; }
            protected set { SetProperty(nameof(ItemSource), ref _ItemSource, value); }
        }

        public U SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(nameof(SelectedItem), ref _SelectedItem, value); }
        }

        #endregion

        #region Constructors

        public ViewModelList(Navigator navigator, T context) : base(navigator, context)
        {
            DbSet<U> items = context.Set<U>();
            items.Load();
            ItemSource = items.Local;
        }

        #endregion

    }
}
