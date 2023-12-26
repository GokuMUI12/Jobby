using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Jobby.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto userForRegistration)
        {
            var response = await _userService.RegisterUser(userForRegistration);

            if (response.Errors != null && response.Errors.Any())
            {
                return BadRequest(response);
            }

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            var response = await _userService.Login(login);

            if (String.IsNullOrEmpty(response.ErrorMessage))
            {
                return Ok(response);
            }
            return Unauthorized(response);

        }

        [HttpGet("get-all-employers")]
        public async Task<IActionResult> GetAllEmployers()
        {
            var response = await _userService.GetAllEmployers();
            return Ok(response);
        }

        [HttpGet("get-all-freelancers")]
        public async Task<IActionResult> GetAllFreelancers()
        {
            var response = await _userService.GetAllFreelancers();
            return Ok(response);
        }
    }
}
