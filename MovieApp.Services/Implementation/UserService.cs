using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MovieApp.Configurations;
using MovieApp.DataAccess.Abstraction;
using MovieApp.Domain.Entities;
using MovieApp.Exceptions;
using MovieApp.Helpers;
using MovieApp.InterfaceModels.Enums;
using MovieApp.InterfaceModels.Models.UserModels;
using MovieApp.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserDto> _userRepository;
        private readonly IRepository<MovieDto> _movieRepository;
        private readonly AppSettings _appSettings;


        public UserService(IRepository<UserDto> userRepository, IRepository<MovieDto> movieRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
            _appSettings = appSettings.Value;
        }

        public UserModel Login(LoginModel model)
        {
            var hashedPassword = PasswordHasher.HashPassword(model.Password);

            var user = _userRepository.GetAll().FirstOrDefault(x => (x.Username == model.LoginProvider || x.Email == model.LoginProvider) && x.Password == hashedPassword);
            if (user == null)
            {
                throw new UserException(400, "Wrong login credentials.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                        new[]
                        {
                            new Claim(ClaimTypes.Name , user.Username),
                            new Claim(ClaimTypes.GivenName , user.FirstName),
                            new Claim(ClaimTypes.Surname , user.LastName),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        }
                    ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                FavouriteGenre = (Genre)user.FavouriteGenre,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public void Register(RegisterModel model)
        {
            ValidateModel(model);
            var user = new UserDto(model.FirstName, model.LastName, model.Username, model.Email, PasswordHasher.HashPassword(model.Password), model.FavouriteGenre);
            _userRepository.Create(user);
        }
        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if(user == null)
            {
                throw new UserException(404, id, $"User with Id:{id} does not exist");
            }
            _userRepository.Delete(user);
        }


        private bool IsUsernameUsed(string username)
        {
            return _userRepository.GetAll().Any(x => x.Username == username);
        }
        private bool IsUsernameValid(string username)
        {
            var usernameRegex = new Regex(@"^[A-z][A-z0-9-_]{5,24}$");
            var match = usernameRegex.Match(username);
            return match.Success;
        }

        private bool IsEmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
        private bool IsEmailUsed(string email)
        {
            return _userRepository.GetAll().Any(x => x.Email == email);
        }

        private bool IsPasswordValid(string password)
        {
            var passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{6,20}$");
            var match = passwordRegex.Match(password);
            return match.Success;
        }

        private void ValidateModel(RegisterModel model)
        {
            if (string.IsNullOrEmpty(model.FirstName))
            {
                throw new UserException(400, "First name is requiered.");
            }
            if (string.IsNullOrEmpty(model.LastName))
            {
                throw new UserException(400, "Last name is requiered.");
            }
            if (string.IsNullOrEmpty(model.Username))
            {
                throw new UserException(400, "Username is requiered.");
            }
            if (IsUsernameUsed(model.Username))
            {
                throw new UserException(400, "Username is already used.");
            }
            if (!IsUsernameValid(model.Username))
            {
                throw new UserException(400, "Please enter a valid username");
            }
            if (string.IsNullOrEmpty(model.Email))
            {
                throw new UserException(400, "Email is requiered.");
            }
            if (!IsEmailValid(model.Email))
            {
                throw new UserException(400, "Please enter a valid email format.");
            }
            if (IsEmailUsed(model.Email))
            {
                throw new UserException(400, "Email is already used.");
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                throw new UserException(400, "Password cannot be empty");
            }
            if (model.Password != model.ConfirmPassword)
            {
                throw new UserException(400, "Passwords do not match");
            }
            if (!IsPasswordValid(model.Password))
            {
                throw new UserException(400, "Please enter a valid password format");
            }
        }

    }
}
