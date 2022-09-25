using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.InterfaceModels.Models.MovieModels
{
    public class SubmitMovieModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public int Year { get; set; }
        public int Genre { get; set; }
    }
}
