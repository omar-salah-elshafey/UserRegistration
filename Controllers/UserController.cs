using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistration.Data;
using UserRegistration.Models;
using UserRegistration.Services;

namespace UserRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationDbContext _context;
        public UserController(IUserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
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

        [HttpGet("governorates")]
        public async Task<IActionResult> GetGovernoratesAsync()
        {
            var governorates = await _context.Governorates
                .Include(g => g.Cities)
                .Select(g => new
                {
                    Id = g.Id,
                    Name = g.Name,
                    Cities = g.Cities.Select(c => new { Id = c.Id, Name = c.Name })
                })
                .ToListAsync();

            return Ok(governorates);
        }

    }
}
