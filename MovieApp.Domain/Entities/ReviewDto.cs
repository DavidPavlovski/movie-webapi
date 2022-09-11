using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain.Entities
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int MovieId { get; set; }
        public MovieDto Movie { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public DateTime Posted { get; set; }

        public ReviewDto()
        {

        }
        public ReviewDto(int rating, string? review, int userId, int movieId)
        {
            Rating = rating;
            Review = review;
            UserId = userId;
            MovieId = movieId;
            Posted = DateTime.Now;
        }
    }
}
