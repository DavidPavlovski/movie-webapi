using MovieApp.Domain.Entities;
using MovieApp.InterfaceModels.Enums;
using MovieApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToMovieDto(this MovieModel model)
        {
            return new MovieDto
            {
                Title = model.Title,
                Description = model.Description,
                PosterUrl = model.PosterUrl,
                Year = model.Year,
                Genre = (int)model.Genre,
            };

        }
        public static MovieModel ToMovieModel(this MovieDto model)
        {
            return new MovieModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                PosterUrl = model.PosterUrl,
                Year = model.Year,
                Genre = (Genre)model.Genre
            };
        }
    }
}
