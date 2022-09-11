using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DataAccess;
using MovieApp.DataAccess.Abstraction;
using MovieApp.DataAccess.Repositories;
using MovieApp.Domain.Entities;
using MovieApp.Services.Abstraction;
using MovieApp.Services.Implementation;

namespace MovieApp.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services, string connetctionString)
        {

            services.AddDbContext<MovieAppDbContext>(options =>
            {
                options.UseSqlServer(connetctionString);
            });

            //Services
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IReviewService, ReviewService>();

            //Repositories
            services.AddTransient<IRepository<MovieDto>, MovieRepository>();
            services.AddTransient<IRepository<UserDto>, UserRepository>();
            services.AddTransient<IRepository<ReviewDto>, ReviewRepository>();

            return services;
        }
    }
}
