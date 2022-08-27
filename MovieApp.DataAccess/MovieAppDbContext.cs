using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public DbSet<MovieDto> Movies { get; set; }

        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieDto>(x => x.ToTable("Movie"));

            builder.Entity<MovieDto>()
                .HasData(
                new MovieDto() { Id = 1, Title = "Star Wars", Description = "Description goes here", PosterUrl= "https://davidkoepp.com/wp-content/themes/blankslate/images/Movie%20Placeholder.jpg" , Year = 1977 , Genre = 7},
                new MovieDto() { Id = 2, Title = "Pulp Fiction", Description = "Description goes here", PosterUrl = "https://davidkoepp.com/wp-content/themes/blankslate/images/Movie%20Placeholder.jpg", Year = 1994, Genre = 5 },
                new MovieDto() { Id = 3, Title = "Die Hard", Description = "Description goes here", PosterUrl = "https://davidkoepp.com/wp-content/themes/blankslate/images/Movie%20Placeholder.jpg", Year = 1988, Genre = 1 }
               );
        }
    }
}
