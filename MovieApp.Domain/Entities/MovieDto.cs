using MovieApp.InterfaceModels.Models;

namespace MovieApp.Domain.Entities
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public int Year { get; set; }
        public int Genre { get; set; }
        public DateTime Posted { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; } 
        public ICollection<ReviewDto> Reviews { get; set; }

        public MovieDto() { }
        public MovieDto(string title, string description, string posterUrl, int year, int genre, int userId)
        {
            Title = title;
            Description = description;
            PosterUrl = posterUrl;
            Year = year;
            Genre = genre;
            Posted = DateTime.Now;
            UserId = userId;
        }

        public void UpdateEntity(UpdateMovieModel model)
        {
            Title = model.Title;
            Description = model.Description;
            PosterUrl = model.PosterUrl;
            Year = model.Year;
            Genre = (int)model.Genre;
        }
    }
}
