using MovieApp.Domain.Entities;
using MovieApp.InterfaceModels.Models.ReviewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Mappers
{
    public static class ReviewMapper
    {
        //public static ReviewDto ToReviewDto(this ReviewModel model)
        //{

        //}

        public static ReviewModel ToReviewModel(this ReviewDto model)
        {
            return new ReviewModel
            {
                Id = model.Id,
                Rating = model.Rating,
                Review = model.Review,
                User = model.User.ToReviewOwnerModel()
            };
        }
    }
}
