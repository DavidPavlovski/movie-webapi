using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain.Entities;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.Models.ReviewModels;
using MovieApp.Mappers;
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
            if (model.Rating > 5 || model.Rating <= 0)
            {
                throw new ReviewException(400, "Status must be between 1 and 5.");
            }
            if (string.IsNullOrEmpty(model.Review))
            {
                throw new ReviewException(400, "Review field cannot be empty");
            }
            var review = new ReviewDto(model.Rating, model.Review, model.UserId, model.MovieId);
            _reviewRepository.Create(review);
        }

        public void Delete(int id)
        {
            var item = _reviewRepository.GetById(id);
            if (item == null)
            {
                throw new ReviewException(404, id, $"Review with Id : {id} does not exist");
            }
            _reviewRepository.Delete(item);
        }

        public ReviewModel GetById(int id)
        {
            var review = _reviewRepository.GetById(id);
            if (review == null)
            {
                throw new ReviewException(404, id, $"Review with Id : {id} does not exist");
            }
            return review.ToReviewModel();
        }

        public void Update(UpdateReviewModel model)
        {
            var updatingEntity = _reviewRepository.GetById(model.Id);
            if (updatingEntity == null)
            {
                throw new ReviewException(404, model.Id, $"Review with Id : {model.Id} does not exist");
            }
            if (model.Rating > 5 || model.Rating <= 0)
            {
                throw new ReviewException(400, "Status must be between 1 and 5.");
            }
            if (string.IsNullOrEmpty(model.Review))
            {
                throw new ReviewException(400, "Review field cannot be empty");
            }
            updatingEntity.Update(model);
            _reviewRepository.Update(updatingEntity);
        }
    }
}
