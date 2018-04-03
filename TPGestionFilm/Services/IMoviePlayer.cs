using DataLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPGestionFilm.Services
{
    public interface IMoviePlayer
    {
        void startPlaying(Movie movie);
    }
}
