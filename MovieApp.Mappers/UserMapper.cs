using MovieApp.Domain.Entities;
using MovieApp.InterfaceModels.Enums;
using MovieApp.InterfaceModels.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Mappers
{
    public static class UserMapper
    {
        public static UserModel ToUserDto(this UserDto model)
        {
            return new UserModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Email = model.Email,
            };
        }

        public static MovieOwnerModel ToMovieOwner(this UserDto model)
        {
            return new MovieOwnerModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Email = model.Username,
                FavouriteGenre = (Genre)model.FavouriteGenre
            };
        }
        public static ReviewOwnerModel ToReviewOwnerModel(this UserDto model)
        {
            return new ReviewOwnerModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Email = model.Username,
                FavouriteGenre = (Genre)model.FavouriteGenre
            };
        }
    }
}
