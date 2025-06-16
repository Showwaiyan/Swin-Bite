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

        [HttpGet("test")]
        public async Task<IActionResult> BrowseRestaurants()
        {
            try
            {
                IEnumerable<Restaurant> restaurants = await _restaurantServices.BrowseRestaurant();
                
                IEnumerable<RestaurantDto> restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

                return Ok(restaurantsDto);
            }
            catch
            {
                return StatusCode(500, "Internal Error Occured");
            }
        }
    }
}
