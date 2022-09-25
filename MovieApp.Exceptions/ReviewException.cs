using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Exceptions
{
    public class ReviewException : Exception
    {
        public int? ReviewId { get; set; }
        public int StatusCode { get; set; }

        public ReviewException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
        public ReviewException(int? movieId, int statusCode, string message) : base(message)
        {
            ReviewId = movieId;
            StatusCode = statusCode;
        }
    }
}
