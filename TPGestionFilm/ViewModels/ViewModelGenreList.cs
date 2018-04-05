using DataLib;
using MVVMutils.Core;
using MVVMutils.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionFilm.ViewModels
{
    public class ViewModelGenreList : ViewModelList<GestionFilmEntities, Genre>
    {
        #region Fields

        private DelegateCommand _SaveCommand;
                
        private DelegateCommand _AddCommand;

        private DelegateCommand _RemoveCommand;

        #endregion

        #region Properties

        public DelegateCommand SaveCommand
        {
            get { return _SaveCommand; }
            set { SetProperty(nameof(SaveCommand), ref _SaveCommand, value); }
        }

        public DelegateCommand AddCommand
        {
            get { return _AddCommand; }
            set { SetProperty(nameof(AddCommand), ref _AddCommand, value); }
        }

        public DelegateCommand RemoveCommand
        {
            get { return _RemoveCommand; }
            set { SetProperty(nameof(RemoveCommand), ref _RemoveCommand, value); }
        }

        #endregion

        #region Constructors

        public ViewModelGenreList(Navigator navigator, GestionFilmEntities context) : base(navigator, context)
        {
            SaveCommand = new DelegateCommand(Save_Execute);
            AddCommand = new DelegateCommand(Add_Execute);
            RemoveCommand = new DelegateCommand(Remove_Execute, Remove_CanExecute);
        }

        #endregion

        #region Methods

        #region SaveCommand

        public void Save_Execute(object parameter)
        {
            Context.SaveChanges();
        }

        #endregion

        #region AddCommand

        public void Add_Execute(object parameter)
        {
            ItemSource.Add(new Genre
            {
                Name = "Nouveau Genre"
            });
        }

        #endregion

        #region RemoveCommand

        public void Remove_Execute(object parameter)
        {
            ItemSource.Remove(SelectedItem);
        }

        public bool Remove_CanExecute(object parameter)
        {
            return SelectedItem != null;
        }

        #endregion

        #endregion



    }
}
