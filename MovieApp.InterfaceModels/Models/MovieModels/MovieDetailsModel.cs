using MovieApp.InterfaceModels.Enums;
using MovieApp.InterfaceModels.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.InterfaceModels.Models.MovieModels
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public MovieOwnerModel User { get; set; }

    }
}
