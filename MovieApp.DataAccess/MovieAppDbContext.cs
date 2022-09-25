using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Helpers;

namespace MovieApp.DataAccess
{
    public class MovieAppDbContext : DbContext
    {
        public DbSet<MovieDto> Movies { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<ReviewDto> Reviews { get; set; }

        public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserDto>(x => x.ToTable("User"));
            builder.Entity<MovieDto>(x => x.ToTable("Movie"));
            builder.Entity<ReviewDto>(x => x.ToTable("Review"));

            builder.Entity<ReviewDto>()
                  .HasOne(r => r.User)
                  .WithMany(u => u.SubmittedReviews)
                  .OnDelete(DeleteBehavior.NoAction)
                  .HasForeignKey(r => r.UserId)
                  .IsRequired(false);

            builder.Entity<ReviewDto>()
                .HasOne(r => r.Movie)
                .WithMany(m => m.Reviews)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(r => r.MovieId);

            builder.Entity<MovieDto>()
                .HasOne(m => m.User)
                .WithMany(u => u.SubmittedMovies)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserDto>().HasData(
                new UserDto("David", "Pavlovski", "dPavlovski", "david.pavlovski@hotmail.com", PasswordHasher.HashPassword("password123"), 1) { Id = 1 },
                new UserDto("Marko", "Pavlovski", "mPavlovski", "marko.pavlovski@hotmail.com", PasswordHasher.HashPassword("password123"), 2) { Id = 2 },
                new UserDto("Rade", "Pavlovski", "rPavlovski", "rade.pavlovski@hotmail.com", PasswordHasher.HashPassword("password123"), 3) { Id = 3 },
                new UserDto("Bob", "Bobsky", "bBobsky", "bob.bobsky@hotmail.com", PasswordHasher.HashPassword("password123"), 4) { Id = 4 }
                );



            builder.Entity<MovieDto>().HasData(
                new MovieDto("Star wars episode 4", "description goes here", "some image url", 1987, 1, 1) { Id = 1 },
                new MovieDto("Star wars episode 5", "description goes here", "some image url", 1987, 1, 1) { Id = 2 },
                new MovieDto("Star wars episode 6", "description goes here", "some image url", 1987, 1, 1) { Id = 3 },
                new MovieDto("Star wars episode 7", "description goes here", "some image url", 1987, 1, 1) { Id = 4 },
                new MovieDto("Harry Potter 1", "description goes here", "some image url", 1987, 1, 2) { Id = 5 },
                new MovieDto("Harry Potter 2", "description goes here", "some image url", 1987, 1, 2) { Id = 6 },
                new MovieDto("Harry Potter 3", "description goes here", "some image url", 1987, 1, 2) { Id = 7 },
                new MovieDto("Harry Potter 4", "description goes here", "some image url", 1987, 1, 2) { Id = 8 },
                new MovieDto("Harry Potter 5", "description goes here", "some image url", 1987, 1, 2) { Id = 9 },
                new MovieDto("Movie 1", "description goes here", "some image url", 1987, 1, 3) { Id = 10 },
                new MovieDto("Movie 2", "description goes here", "some image url", 1987, 1, 3) { Id = 11 },
                new MovieDto("Movie 3", "description goes here", "some image url", 1987, 1, 3) { Id = 12 },
                new MovieDto("Movie 4", "description goes here", "some image url", 1987, 1, 3) { Id = 13 },
                new MovieDto("Movie 5", "description goes here", "some image url", 1987, 1, 3) { Id = 14 },
                new MovieDto("Movie 6", "description goes here", "some image url", 1987, 1, 4) { Id = 15 },
                new MovieDto("Movie 7", "description goes here", "some image url", 1987, 1, 4) { Id = 16 },
                new MovieDto("Movie 8", "description goes here", "some image url", 1987, 1, 4) { Id = 17 },
                new MovieDto("Movie 9", "description goes here", "some image url", 1987, 1, 4) { Id = 18 }
                );

            builder.Entity<ReviewDto>().HasData(
                new ReviewDto(5, "Review from user 1 - 1 ", 1, 1) { Id = 1 },
                new ReviewDto(5, "Review from user 1 - 2 ", 1, 2) { Id = 2 },
                new ReviewDto(5, "Review from user 1 - 3 ", 1, 3) { Id = 3 },
                new ReviewDto(5, "Review from user 1 - 4 ", 1, 4) { Id = 4 },
                new ReviewDto(5, "Review from user 1 - 5 ", 1, 5) { Id = 5 },
                new ReviewDto(5, "Review from user 1 - 6 ", 1, 6) { Id = 6 },
                new ReviewDto(5, "Review from user 1 - 7 ", 1, 7) { Id = 7 },
                new ReviewDto(5, "Review from user 1 - 8 ", 1, 8) { Id = 8 },
                new ReviewDto(5, "Review from user 1 - 9 ", 1, 9) { Id = 9 },
                new ReviewDto(5, "Review from user 1 - 10 ", 1, 10) { Id = 10 },
                new ReviewDto(5, "Review from user 1 - 11 ", 1, 11) { Id = 11 },
                new ReviewDto(5, "Review from user 1 - 12 ", 1, 12) { Id = 12 },
                new ReviewDto(5, "Review from user 1 - 13 ", 1, 13) { Id = 13 },
                new ReviewDto(5, "Review from user 1 - 14 ", 1, 14) { Id = 14 },
                new ReviewDto(5, "Review from user 1 - 15 ", 1, 15) { Id = 15 },
                new ReviewDto(5, "Review from user 1 - 16 ", 1, 16) { Id = 16 },
                new ReviewDto(5, "Review from user 1 - 17 ", 1, 17) { Id = 17 },
                new ReviewDto(5, "Review from user 1 - 18 ", 1, 18) { Id = 18 },

                new ReviewDto(5, "Review from user 2 - 1 ", 2, 1) { Id = 19 },
                new ReviewDto(5, "Review from user 2 - 2 ", 2, 2) { Id = 20 },
                new ReviewDto(5, "Review from user 2 - 3 ", 2, 3) { Id = 21 },
                new ReviewDto(5, "Review from user 2 - 4 ", 2, 4) { Id = 22 },
                new ReviewDto(5, "Review from user 2 - 5 ", 2, 5) { Id = 23 },
                new ReviewDto(5, "Review from user 2 - 6 ", 2, 6) { Id = 24 },
                new ReviewDto(5, "Review from user 2 - 7 ", 2, 7) { Id = 25 },
                new ReviewDto(5, "Review from user 2 - 8 ", 2, 8) { Id = 26 },
                new ReviewDto(5, "Review from user 2 - 9 ", 2, 9) { Id = 27 },
                new ReviewDto(5, "Review from user 2 - 10 ", 2, 10) { Id = 28 },
                new ReviewDto(5, "Review from user 2 - 11 ", 2, 11) { Id = 29 },
                new ReviewDto(5, "Review from user 2 - 12 ", 2, 12) { Id = 30 },
                new ReviewDto(5, "Review from user 2 - 13 ", 2, 13) { Id = 31 },
                new ReviewDto(5, "Review from user 2 - 14 ", 2, 14) { Id = 32 },
                new ReviewDto(5, "Review from user 2 - 15 ", 2, 15) { Id = 33 },
                new ReviewDto(5, "Review from user 2 - 16 ", 2, 16) { Id = 34 },
                new ReviewDto(5, "Review from user 2 - 17 ", 2, 17) { Id = 35 },
                new ReviewDto(5, "Review from user 2 - 18 ", 2, 18) { Id = 36 },

                new ReviewDto(5, "Review from user 3 - 1 ", 3, 1) { Id = 37 },
                new ReviewDto(5, "Review from user 3 - 2 ", 3, 2) { Id = 38 },
                new ReviewDto(5, "Review from user 3 - 3 ", 3, 3) { Id = 39 },
                new ReviewDto(5, "Review from user 3 - 4 ", 3, 4) { Id = 40 },
                new ReviewDto(5, "Review from user 3 - 5 ", 3, 5) { Id = 41 },
                new ReviewDto(5, "Review from user 3 - 6 ", 3, 6) { Id = 42 },
                new ReviewDto(5, "Review from user 3 - 7 ", 3, 7) { Id = 43 },
                new ReviewDto(5, "Review from user 3 - 8 ", 3, 8) { Id = 44 },
                new ReviewDto(5, "Review from user 3 - 9 ", 3, 9) { Id = 45 },
                new ReviewDto(5, "Review from user 3 - 10 ", 3, 10) { Id = 46 },
                new ReviewDto(5, "Review from user 3 - 11 ", 3, 11) { Id = 47 },
                new ReviewDto(5, "Review from user 3 - 12 ", 3, 12) { Id = 48 },
                new ReviewDto(5, "Review from user 3 - 13 ", 3, 13) { Id = 49 },
                new ReviewDto(5, "Review from user 3 - 14 ", 3, 14) { Id = 50 },
                new ReviewDto(5, "Review from user 3 - 15 ", 3, 15) { Id = 51 },
                new ReviewDto(5, "Review from user 3 - 16 ", 3, 16) { Id = 52 },
                new ReviewDto(5, "Review from user 3 - 17 ", 3, 17) { Id = 53 },
                new ReviewDto(5, "Review from user 3 - 18 ", 3, 18) { Id = 54 },

                new ReviewDto(5, "Review from user 4 - 1 ", 4, 1) { Id = 55 },
                new ReviewDto(5, "Review from user 4 - 2 ", 4, 2) { Id = 56 },
                new ReviewDto(5, "Review from user 4 - 3 ", 4, 3) { Id = 57 },
                new ReviewDto(5, "Review from user 4 - 4 ", 4, 4) { Id = 58 },
                new ReviewDto(5, "Review from user 4 - 5 ", 4, 5) { Id = 59 },
                new ReviewDto(5, "Review from user 4 - 6 ", 4, 6) { Id = 60 },
                new ReviewDto(5, "Review from user 4 - 7 ", 4, 7) { Id = 61 },
                new ReviewDto(5, "Review from user 4 - 8 ", 4, 8) { Id = 62 },
                new ReviewDto(5, "Review from user 4 - 9 ", 4, 9) { Id = 63 },
                new ReviewDto(5, "Review from user 4 - 10 ", 4, 10) { Id = 64 },
                new ReviewDto(5, "Review from user 4 - 11 ", 4, 11) { Id = 65 },
                new ReviewDto(5, "Review from user 4 - 12 ", 4, 12) { Id = 66 },
                new ReviewDto(5, "Review from user 4 - 13 ", 4, 13) { Id = 67 },
                new ReviewDto(5, "Review from user 4 - 14 ", 4, 14) { Id = 68 },
                new ReviewDto(5, "Review from user 4 - 15 ", 4, 15) { Id = 69 },
                new ReviewDto(5, "Review from user 4 - 16 ", 4, 16) { Id = 70 },
                new ReviewDto(5, "Review from user 4 - 17 ", 4, 17) { Id = 71 },
                new ReviewDto(5, "Review from user 4 - 18 ", 4, 18) { Id = 72 }
                );
        }
    }
}
