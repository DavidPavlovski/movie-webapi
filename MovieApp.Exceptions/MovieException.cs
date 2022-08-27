using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Exceptions
{
    public class MovieException : Exception
    {
        public MovieException() : base("Something went wrong.Try again later.")
        {

        }
        public MovieException(string message) : base(message)
        {
        }
    }
}
