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
        public async Task<IActionResult> ViewMenu(int restaruantId)
        {
            try
            {
                IEnumerable<Food> foods = await _restaurantServices.GetMenu(restaruantId);
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

        [HttpPost("order")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] OrderStatusDto orderStatusDto)
        {
            try
            {
                Order order = await _orderServices.GetOrder(orderStatusDto.OrderId);
                order = await _restaurantServices.UpdateOrderStatus(order, orderStatusDto.Status);
                await _orderServices.UpdateOrder(order);
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                return Ok(orderDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId, [FromBody] UserDto userDto)
        {
            try
            {
                Order order = await _restaurantServices.GetOrder(orderId, userDto.UserId);
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
