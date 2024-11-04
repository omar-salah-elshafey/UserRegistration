using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;
using UserRegistration.Services;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _userService.GetAllAsync();
            if (users == null || !users.Any())
                return NotFound("No users found!");
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegistrationModel registrationModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.RegisterAsync(registrationModel);
            if (!result.isCreated)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
