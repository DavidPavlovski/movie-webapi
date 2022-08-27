using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.Models;
using MovieApp.Services.Abstraction;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

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
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }
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
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

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
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }


        [HttpPost("AddNewMovie")]
        public IActionResult Create([FromBody] MovieModel model)
        {
            try
            {

                _movieService.Create(model);
                return Ok("Movie added Successfully!");
            }
            catch (MovieException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

        [HttpPut("EditMovie")]
        public IActionResult Update([FromBody] MovieModel model)
        {
            try
            {

                _movieService.Update(model);
                return Ok("Movie Edited Successfully!");
            }
            catch (MovieException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

        [HttpDelete("DeleteMovieById/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {

                _movieService.DeleteById(id);
                return Ok("Movie deleted Successfully!");
            }
            catch (MovieException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong. Please try again.");
            }
        }

    }
}
