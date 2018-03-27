using MVVMutils.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPGestionFilm.ViewModels;
using TPGestionFilm.Views;
using Unity;

namespace TPGestionFilm
{
    class Bootstrapper
    {

        public void Start()
        {
            // On créé le container d'injection
            UnityContainer container = new UnityContainer();

            // On effectue les registerations

            // On créé le builder
            container.RegisterInstance<IViewModelBuilder>(new UnityViewModelBuilder(container));

            // On démarre le shell de l'application
            Shell shell = new Shell
            {
                DataContext = container.Resolve<ViewModelShell>()
            };
            shell.Show();
        }

    }
}
