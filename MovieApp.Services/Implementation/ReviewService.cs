using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain.Entities;
using MovieApp.InterfaceModels.Models;
using MovieApp.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementation
{
    public class ReviewService : IReviewService
    {

        private readonly IRepository<ReviewDto> _reviewRepository;


        public ReviewService(IRepository<ReviewDto> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public void Create(SubmitReviewModel model)
        {
            var review = new ReviewDto(model.Rating, model.Review, model.UserId, model.MovieId);
            _reviewRepository.Create(review);
        }
    }
}
