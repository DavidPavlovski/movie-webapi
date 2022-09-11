using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieApp.Configurations;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.Models;
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
        public IActionResult Edit()
        {
            return Ok();
        }


        [HttpDelete("DeleteReview")]
        public IActionResult Delete()
        {
            return Ok();
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
