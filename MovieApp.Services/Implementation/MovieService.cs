using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain.Entities;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.Models;
using MovieApp.Mappers;
using MovieApp.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<MovieDto> _movieRepository;

        public MovieService(IRepository<MovieDto> movieRepository)
        {
            _movieRepository = movieRepository;
        }


        public List<MovieModel> GetAll()
        {
            return _movieRepository.GetAll()
                                   .Select(x => x.ToMovieModel())
                                   .ToList();
        }
        public List<MovieModel> GetByGenre(int genre)
        {
            return _movieRepository.GetByGenre(genre)
                                   .Select(x => x.ToMovieModel())
                                   .ToList();
        }

        public MovieModel GetById(int id)
        {
            var res = _movieRepository.GetById(id)
                                   .ToMovieModel();
            if (res == null)
            {
                throw new MovieException($"Movie with Id : {id} does not exist");
            }
            return res;
        }


        public void Create(MovieModel model)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MovieException("Movie Title cannot be empty");
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new MovieException("Movie Description cannot be empty");
            }
            if (string.IsNullOrEmpty(model.PosterUrl))
            {
                throw new MovieException("Movie Poster Url cannot be empty");
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MovieException("Movie Title cannot be empty");
            }

            _movieRepository.Create(model.ToMovieDto());
        }

        public void Update(MovieModel model)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MovieException("Movie Title cannot be empty");
            }
            if (string.IsNullOrEmpty(model.Description))
            {
                throw new MovieException("Movie Description cannot be empty");
            }
            if (string.IsNullOrEmpty(model.PosterUrl))
            {
                throw new MovieException("Movie Poster Url cannot be empty");
            }
            if (string.IsNullOrEmpty(model.Title))
            {
                throw new MovieException("Movie Title cannot be empty");
            }
            var item = _movieRepository.GetById(model.Id);
            if (item == null)
            {
                throw new MovieException($"Movie with Id : {model.Id} does not exist");
            }
            item.UpdateEntity(model);
            _movieRepository.Update(item);
        }

        public void DeleteById(int id)
        {
            var item = _movieRepository.GetById(id);
            if (item == null)
            {
                throw new MovieException($"Movie with Id: {id} does not exist");
            }
            _movieRepository.Delete(item);
        }

    }
}
