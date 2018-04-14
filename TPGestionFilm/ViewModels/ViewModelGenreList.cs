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
    /// <summary>
    /// Vue modele assurant la gestion des genres connus par l'application
    /// </summary>
    public class ViewModelGenreList : ViewModelListSelectable<GestionFilmEntities, Genre>
    {
        #region Fields

        private DelegateCommand _SaveCommand;
                
        private DelegateCommand _AddCommand;

        private DelegateCommand _RemoveCommand;

        #endregion

        #region Properties

        /// <summary>
        /// Commande pour sauvegarder la liste des genres
        /// </summary>
        public DelegateCommand SaveCommand
        {
            get { return _SaveCommand; }
            set { SetProperty(nameof(SaveCommand), ref _SaveCommand, value); }
        }

        /// <summary>
        /// Commande pour ajouter un nouveau genre
        /// </summary>
        public DelegateCommand AddCommand
        {
            get { return _AddCommand; }
            set { SetProperty(nameof(AddCommand), ref _AddCommand, value); }
        }

        /// <summary>
        /// Commande pour effacer un genre
        /// </summary>
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
