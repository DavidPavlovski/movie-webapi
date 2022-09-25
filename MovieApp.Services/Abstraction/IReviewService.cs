using MovieApp.InterfaceModels.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Abstraction
{
    public interface IReviewService
    {
        void Create(SubmitReviewModel model);
        void Update(UpdateReviewModel model);
        ReviewModel GetById(int id);
        void Delete(int id);
    }
}
