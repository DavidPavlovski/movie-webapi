using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Repositories
{
    public class MovieStaticRepository : IRepository<MovieDto>
    {

        public IEnumerable<MovieDto> GetAll()
        {
            return StaticDb.Movies;
        }
        public IEnumerable<MovieDto> GetByGenre(int genre)
        {
            return StaticDb.Movies.Where(x => x.Genre == genre);
        }

        public MovieDto GetById(int id)
        {
            return StaticDb.Movies.SingleOrDefault(x => x.Id == id);
        }

        public void Create(MovieDto entity)
        {
            entity.Id = StaticDb.MovieIdCounter++;
            StaticDb.Movies.Add(entity);
        }
        public void Update(MovieDto entity)
        {
            var item = GetById(entity.Id);
            item.Title = entity.Title;
            item.Description = entity.Description;
            item.PosterUrl = entity.PosterUrl;
            item.Year = entity.Year;
            item.Genre = entity.Genre;
        }

        public void Delete(MovieDto entity)
        {
            StaticDb.Movies.Remove(entity);
        }


    }
}
