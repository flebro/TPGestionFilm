using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DataLib;

namespace TPGestionFilm.Services
{
    /// <summary>
    /// Mock implémentation du IMoviePlayer pour le débuggage
    /// </summary>
    public class StubMoviePlayer : IMoviePlayer
    {
        public void startPlaying(Movie movie)
        {
            MessageBox.Show("Je lis le film : " + movie.Name);
        }
    }
}
