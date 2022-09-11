using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int FavouriteGenre { get; set; }
        public ICollection<MovieDto> SubmittedMovies { get; set; }
        public ICollection<ReviewDto> SubmittedReviews { get; set; }
        public UserDto() { }
        public UserDto(string firstName, string lastName, string username, string email, string password, int favouriteGenre)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Password = password;
            FavouriteGenre = favouriteGenre;
        }
    }
}
