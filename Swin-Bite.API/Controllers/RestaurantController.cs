using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwinBite.DTO;
using SwinBite.Models;
using SwinBite.Services;

namespace SwinBite.Controller
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly RestaurantServices _restaurantServices;

        public RestaurantController(RestaurantServices restaurantServices, IMapper mapper)
        {
            _restaurantServices = restaurantServices;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> BrowseRestaurants([FromQuery] string? name)
        {
            try
            {
                IEnumerable<Restaurant> restaurants = null;
                if (string.IsNullOrEmpty(name))
                {
                    restaurants = await _restaurantServices.GetRestaurants();
                }
                else restaurants = await _restaurantServices.FindRestaruants(name);

                IEnumerable<RestaurantDto> restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

                return Ok(restaurantsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error Occured");
            }
        }

        [HttpGet("menu")]
        public async Task<IActionResult> ViewMenu([FromBody] MenuRequestDto menuRequestDto)
        {
            try
            {
                IEnumerable<Food> foods = await _restaurantServices.GetMenu(menuRequestDto.RestaurantId);
                IEnumerable<FoodDto> foodsDto = _mapper.Map<IEnumerable<FoodDto>>(foods);
                return Ok(foodsDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error Occured");
            }
        }
    }
}
