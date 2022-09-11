using MovieApp.InterfaceModels.Models;

namespace MovieApp.Services.Abstraction
{
    public interface IMovieService
    {
        List<MovieDetailsModel> GetAll();
        List<MovieDetailsModel> GetByGenre(int genre);
        MovieDetailsModel GetById(int id);
        void Create(SubmitMovieModel model , int userId);
        void Update(UpdateMovieModel model);
        void DeleteById(int id);
    }
}
