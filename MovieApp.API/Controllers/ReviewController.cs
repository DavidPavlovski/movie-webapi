using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieApp.Configurations;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.Models.ReviewModels;
using MovieApp.Services.Abstraction;
using System.Security.Claims;

namespace MovieApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly AppSettings _appSettings;

        public ReviewController(IReviewService reviewService, IOptions<AppSettings> appSettings)
        {
            _reviewService = reviewService;
            _appSettings = appSettings.Value;
        }

        [HttpPost("SubmitReview")]
        public IActionResult Create([FromBody] SubmitReviewModel model)
        {
            try
            {
                var userId = GetAuthorizedId();
                if (model.UserId != userId)
                {
                    throw new Exception();
                }
                _reviewService.Create(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }


        [HttpPut("EditReview")]
        public IActionResult Edit([FromBody] UpdateReviewModel model)
        {
            try
            {

                var authorizedUserId = GetAuthorizedId();
                if (model.UserId != authorizedUserId)
                {
                    throw new UserException(403, authorizedUserId, "You are not authorized to perform this action");
                }
                _reviewService.Update(model);
                return Ok("Review updated successfully.");
            }
            catch (UserException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
            }
        }


        [HttpDelete("Delete/Id/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                var item = _reviewService.GetById(id);
                var userId = GetAuthorizedId();
                if (item.User.Id != userId)
                {
                    throw new UserException(403, item.User.Id, "You are not authorized to perform this action");
                }
                _reviewService.Delete(id);
                return Ok("Review deleted successfully");
            }
            catch (ReviewException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (UserException ex)
            {
                return StatusCode(ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(_appSettings.DefaultErrorMessage);
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
