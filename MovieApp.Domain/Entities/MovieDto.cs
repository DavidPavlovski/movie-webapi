using MovieApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public int Year { get; set; }
        public int Genre { get; set; }

        public void UpdateEntity(MovieModel model)
        {
            Title = model.Title;
            Description = model.Description;
            PosterUrl = model.PosterUrl;
            Year = model.Year;
            Genre = (int)model.Genre;
        }
    }
}
