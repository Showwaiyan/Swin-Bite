using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwinBite.DTO;
using SwinBite.Interface;
using SwinBite.Models;

namespace SwinBite.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ICustomerServices _customerServices;
        private readonly IMapper _mapper;

        public AuthController(
            IUserServices userServices,
            ICustomerServices customerServices,
            IMapper mapper
        )
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpPost("customers/register")]
        public async Task<IActionResult> Register([FromBody] CreateCustomerDto createCustomerDto)
        {
            try
            {
                Customer newCustomer = await _customerServices.Register(createCustomerDto);

                UserDto newUser = _mapper.Map<UserDto>(newCustomer);
                return StatusCode(201, newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Error Occured: {ex.Message}");
            }
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

        [HttpPost("logout")]
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

        [HttpPatch("update")]
        public async Task<IActionResult> UpdateProfile([FromBody] UserDto userDto)
        {
            try
            {
                User userUpdate = _mapper.Map<User>(userDto);
                User user = await _userServices.UpdateProfile(userUpdate);
                UserDto userUpdatedDto = _mapper.Map<UserDto>(user);
                return Ok(userUpdatedDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
