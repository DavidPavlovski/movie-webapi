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
      
        public static EntityOwnerModel ToEntityOwnerModel(this UserDto model)
        {
            return new EntityOwnerModel
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
