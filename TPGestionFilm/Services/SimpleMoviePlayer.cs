using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLib;

namespace TPGestionFilm.Services
{
    /// <summary>
    /// Un simple player qui délègue la lecture à l'application par défaut
    /// </summary>
    public class SimpleMoviePlayer : IMoviePlayer
    {
        /// <summary>
        /// Démarre la lecture du fichier avec le lecteur par défaut
        /// </summary>
        /// <param name="movie"></param>
        public void startPlaying(Movie movie)
        {
            Process.Start(movie.Data);
        }
    }
}
