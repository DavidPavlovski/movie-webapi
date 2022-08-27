using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Repositories
{
    public class MovieRepository : IRepository<MovieDto>
    {

        private readonly MovieAppDbContext _dbContext;
        public MovieRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return _dbContext.Movies;
        }

        public IEnumerable<MovieDto> GetByGenre(int genre)
        {
            return _dbContext.Movies.Where(x => x.Genre == genre);
        }

        public MovieDto GetById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(x => x.Id == id);
        }
        public void Create(MovieDto entity)
        {
            _dbContext.Movies.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(MovieDto entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(MovieDto entity)
        {
            _dbContext.Movies.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}
