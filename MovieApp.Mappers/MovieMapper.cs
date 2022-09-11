using MovieApp.Domain.Entities;
using MovieApp.InterfaceModels.Enums;
using MovieApp.InterfaceModels.Models;

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
                UserId = model.UserId
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
                Genre = (Genre)model.Genre,
                UserId = model.UserId,
            };
        }


        public static MovieDetailsModel ToMovieDetails(this MovieDto model)
        {
            return new MovieDetailsModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                PosterUrl = model.PosterUrl,
                Year = model.Year,
                Genre = (Genre)model.Genre,
                User = model.User.ToMovieOwner(),
            };

        }
    }
}
