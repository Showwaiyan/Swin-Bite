using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwinBite.DTO;
using SwinBite.Models;
using SwinBite.Services;

namespace SwinBite.Controller
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly RestaurantServices _restaurantServices;
        private readonly OrderServices _orderServices;

        public RestaurantController(
            RestaurantServices restaurantServices,
            OrderServices orderServices,
            IMapper mapper
        )
        {
            _restaurantServices = restaurantServices;
            _orderServices = orderServices;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> BrowseRestaurants([FromQuery] string name)
        {
            try
            {
                IEnumerable<Restaurant> restaurants = null;
                if (string.IsNullOrEmpty(name))
                {
                    restaurants = await _restaurantServices.GetRestaurants();
                }
                else
                    restaurants = await _restaurantServices.FindRestaruantsByName(name);

                IEnumerable<RestaurantDto> restaurantsDto = _mapper.Map<IEnumerable<RestaurantDto>>(
                    restaurants
                );

                return Ok(restaurantsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Error Occured: {ex.Message}");
            }
        }

        [HttpGet("{id}/menu")]
        public async Task<IActionResult> ViewMenu(int id)
        {
            try
            {
                IEnumerable<Food> foods = await _restaurantServices.GetMenu(id);
                IEnumerable<FoodDto> foodsDto = _mapper.Map<IEnumerable<FoodDto>>(foods);
                return Ok(foodsDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Error Occured {ex.Message}");
            }
        }

        [HttpPost("order/{id}/{status}")]
        public async Task<IActionResult> UpdateOrderStatus(
            int id,
            OrderStatus status,
            [FromBody] UserDto userDto
        )
        {
            try
            {
                Order order = await _restaurantServices.UpdateOrderStatus(
                    id,
                    status,
                    userDto.UserId
                );
                await _orderServices.UpdateOrder(order);
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                return Ok(orderDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
