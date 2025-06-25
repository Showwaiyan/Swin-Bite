using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwinBite.DTO;
using SwinBite.Models;
using SwinBite.Services;

namespace SwinBite.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserServices _userServices;
        private readonly IMapper _mapper;

        public AuthController(UserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                string username = loginDto.Username;
                string password = loginDto.Password;

                User user = await _userServices.Login(username, password);
                UserDto userDto = _mapper.Map<UserDto>(user);

                return Ok(userDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("logout")]
        public async Task<IActionResult> Logout([FromBody] UserDto userDto)
        {
            try
            {
                await _userServices.Logout(userDto.UserId);
                return Ok("Successfully Logout");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
