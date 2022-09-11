using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieApp.Configurations;
using MovieApp.Exceptions;
using MovieApp.InterfaceModels.Models;
using MovieApp.Services.Abstraction;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
        }
        [HttpPost("Login")]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            try
            {

                var res = _userService.Login(model);
                return Ok(res);
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

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            try
            {
                _userService.Register(model);
                return Ok();
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
    }
}
