using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccess
{
    public static class StaticDb
    {
        public static int MovieIdCounter = 1;
        public static List<MovieDto> Movies = new List<MovieDto>();

    }
}
