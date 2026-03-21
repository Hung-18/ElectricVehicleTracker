using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.DTOs;

namespace ElectricVehicleTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _iUserService;
        public AuthController(IUserService iUserService)
        {
            _iUserService = iUserService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDto)
        {
            var token = await _iUserService.Login(loginDto);
            if (token == null) return Unauthorized();
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value; 
            if(string.IsNullOrEmpty(userId)) return Unauthorized();
            var user = await _iUserService.GetUserByIdAsync(userId);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDTO registerUserDto)
        {
            await _iUserService.Register(registerUserDto);
            return Ok(new { message = "Register success" });
        }
    }
}
