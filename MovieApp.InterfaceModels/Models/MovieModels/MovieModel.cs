using MovieApp.InterfaceModels.Enums;

namespace MovieApp.InterfaceModels.Models.MovieModels
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public int UserId { get; set; }
    }
}
