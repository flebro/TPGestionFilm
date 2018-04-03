﻿using DataLib;
using MVVMutils.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPGestionFilm.Services;
using TPGestionFilm.ViewModels;
using TPGestionFilm.Views;
using Unity;

namespace TPGestionFilm
{
    class Bootstrapper
    {

        public void Start()
        {
            #region IOC Init

            // On créé le container d'injection et on l'enregistre
            IUnityContainer container = new UnityContainer();
            container.RegisterInstance<IUnityContainer>(container);

            #endregion

            #region Registerations

            // On effectue les registerations
            container.RegisterSingleton<IViewModelLocator, UnityViewModelLocator>();
            container.RegisterType<GestionFilmDMEntities>();

            #region Services

            container.RegisterType<IMoviePlayer, StubMoviePlayer>();

            #endregion

            #region ViewModels

            container.RegisterType<ViewModelMovie>();

            #endregion

            #endregion

            #region Start Up

            // On démarre le shell de l'application
            Shell shell = new Shell
            {
                DataContext = container.Resolve<ViewModelShell>()
            };
            shell.Show();

            #endregion
        }

    }
}
