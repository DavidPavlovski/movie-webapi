using MovieApp.InterfaceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstraction
{
    public interface IMovieService
    {
        List<MovieModel> GetAll();
        List<MovieModel> GetByGenre(int genre);
        MovieModel GetById(int id);
        void Create(MovieModel model);
        void Update(MovieModel model);
        void DeleteById(int id);
    }
}
