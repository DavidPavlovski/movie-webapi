using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain.Entities;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.Models.MovieModels;
using MovieApp.Mappers;
using MovieApp.Services.Abstraction;

namespace MovieApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<MovieDto> _movieRepository;

        public MovieService(IRepository<MovieDto> movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public List<MovieDetailsModel> GetAll()
        {
            return _movieRepository.GetAll()
                                   .Select(x => x.ToMovieDetails())
                                   .ToList();
        }
        public List<MovieDetailsModel> GetByGenre(int genre)
        {
            return _movieRepository.GetByGenre(genre)
                                   .Select(x => x.ToMovieDetails())
                                   .ToList();
        }

        public MovieDetailsModel GetById(int id)
        {
            var res = _movieRepository.GetById(id);
            if (res == null)
            {
                throw new MovieException(404, id, $"Movie with Id : {id} does not exist");
            }
            return res.ToMovieDetails();
        }


        public void Create(SubmitMovieModel model, int userId)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MovieException(400, "Movie Title cannot be empty");
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new MovieException(400, "Movie Description cannot be empty");
            }
            if (string.IsNullOrEmpty(model.PosterUrl))
            {
                throw new MovieException(400, "Movie Poster Url cannot be empty");
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MovieException(400, "Movie Title cannot be empty");
            }
            var movie = new MovieDto(model.Title, model.Description, model.PosterUrl, model.Year, model.Genre, userId);
            _movieRepository.Create(movie);
        }

        public void Update(UpdateMovieModel model)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MovieException(400, "Movie Title cannot be empty");
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new MovieException(400, "Movie Description cannot be empty");
            }
            if (string.IsNullOrEmpty(model.PosterUrl))
            {
                throw new MovieException(400, "Movie Poster Url cannot be empty");
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MovieException(400, "Movie Title cannot be empty");
            }
            var item = _movieRepository.GetById(model.Id);
            if (item == null)
            {
                throw new MovieException(404, model.Id, $"Movie with Id : {model.Id} does not exist");
            }
            item.UpdateEntity(model);
            _movieRepository.Update(item);
        }

        public void DeleteById(int id)
        {
            var item = _movieRepository.GetById(id);
            if (item == null)
            {
                throw new MovieException(404, id, $"Movie with Id: {id} does not exist");
            }
            _movieRepository.Delete(item);
        }

    }
}
