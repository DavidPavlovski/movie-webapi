using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.DataAccess;
using MovieApp.DataAccess.Abstraction;
using MovieApp.DataAccess.Repositories;
using MovieApp.Domain.Entities;
using MovieApp.Services.Abstraction;
using MovieApp.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Utilities
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services , string connetctionString)
        {

            services.AddDbContext<MovieAppDbContext>(options =>
            {
                options.UseSqlServer(connetctionString);
            });

            //Services
            services.AddTransient<IMovieService, MovieService>();

            //Repositories
            //services.AddTransient<IRepository<MovieDto>, MovieStaticRepository>();
            services.AddTransient<IRepository<MovieDto>, MovieRepository>();

            return services;
        }
    }
}
