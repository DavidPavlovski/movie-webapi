namespace MovieApp.Exceptions
{
    public class MovieException : Exception
    {

        public int? MovieId { get; set; }
        public int StatusCode { get; set; }

        public MovieException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public MovieException(int? movieId, int statusCode, string message) : base(message)
        {
            MovieId = movieId;
            StatusCode = statusCode;
        }

    }
}
