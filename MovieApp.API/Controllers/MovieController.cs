using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.Models;
using MovieApp.Services.Abstraction;
using System.Security.Claims;

namespace MovieApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [AllowAnonymous]
        [HttpGet("GetAllMovies")]
        public IActionResult GetAll()
        {
            try
            {
                var res = _movieService.GetAll();
                return Ok(res);
            }
            catch (MovieException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }
        [AllowAnonymous]
        [HttpGet("GetByGenre/{genre}")]
        public IActionResult GetByGenre([FromRoute] int genre)
        {
            try
            {
                var res = _movieService.GetByGenre(genre);
                return Ok(res);
            }

            catch (MovieException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);

            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }
        [AllowAnonymous]
        [HttpGet("GetMovieById/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var res = _movieService.GetById(id);
                return Ok(res);
            }
            catch (MovieException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }


        [HttpPost("AddNewMovie")]
        public IActionResult Create([FromBody] SubmitMovieModel model)
        {
            try
            {
                var userId = GetAuthorizedId();
                _movieService.Create(model, userId);
                return Ok("Movie added Successfully!");
            }
            catch (MovieException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (UserException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

        [HttpPut("EditMovie")]
        public IActionResult Update([FromBody] UpdateMovieModel model)
        {
            try
            {
                var ownerId = GetAuthorizedId();

                if (ownerId != model.UserId)
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                _movieService.Update(model);
                return Ok("Movie Edited Successfully!");
            }
            catch (MovieException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);

            }
            catch (UserException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

        [HttpDelete("DeleteMovieById/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var movie = _movieService.GetById(id);
                var ownerId = GetAuthorizedId();
                if (movie.User.Id != ownerId)
                {
                    throw new UserException(401, "You are not authorized to perform this action.");
                }
                _movieService.DeleteById(id);
                return Ok("Movie deleted Successfully!");
            }
            catch (MovieException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);

            }
            catch (UserException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

        private int GetAuthorizedId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int userId))
            {
                throw new UserException(userId, "Name identifier claim does not exist!");
            }
            return userId;
        }
    }
}
