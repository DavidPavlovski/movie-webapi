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
    public class UserRepository : IRepository<UserDto>
    {

        private readonly MovieAppDbContext _dbContext;
        public UserRepository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(UserDto entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(UserDto entity)
        {
            foreach(var r in entity.SubmittedReviews)
            {
                r.UserId = null;
            }
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }


        public IEnumerable<UserDto> GetAll()
        {
            return _dbContext.Users;
        }

        public IEnumerable<UserDto> GetByGenre(int genre)
        {
            throw new NotImplementedException();
        }

        public UserDto GetById(int id)
        {
            return _dbContext.Users.Include(x => x.SubmittedMovies).Include(x => x.SubmittedReviews).FirstOrDefault(x => x.Id == id);
        }

        public void Update(UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
