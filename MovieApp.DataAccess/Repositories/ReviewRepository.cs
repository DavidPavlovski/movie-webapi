using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess.Repositories
{
    public class ReviewRepository : IRepository<ReviewDto>
    {

        private readonly MovieAppDbContext _dbContext;

        public ReviewRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(ReviewDto entity)
        {
            _dbContext.Reviews.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(ReviewDto entity)
        {
            _dbContext.Reviews.Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<ReviewDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReviewDto> GetByGenre(int genre)
        {
            throw new NotImplementedException();
        }

        public ReviewDto GetById(int id)
        {
            return _dbContext.Reviews.Include(x => x.User).SingleOrDefault(x => x.Id == id);
        }

        public void Update(ReviewDto entity)
        {
            _dbContext.Reviews.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
