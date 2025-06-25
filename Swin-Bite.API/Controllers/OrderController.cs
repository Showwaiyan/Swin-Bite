using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwinBite.DTO;
using SwinBite.Models;
using SwinBite.Services;

namespace SwinBite.Controller
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CustomerServices _customerServices;
        private readonly RestaurantServices _restaurantServices;

        public OrderController(
            CustomerServices customerServices,
            RestaurantServices restaruatnServices,
            IMapper mapper
        )
        {
            _customerServices = customerServices;
            _restaurantServices = restaruatnServices;
            _mapper = mapper;
        }

        [HttpGet("customer")]
        public async Task<IActionResult> GetCustomerOrders([FromBody] UserDto userDto)
        {
            try
            {
                IEnumerable<Order> orders = await _customerServices.GetOrders(userDto.UserId);

                IEnumerable<OrderDto> ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
                return Ok(ordersDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetCustomerOrder(int id, [FromBody] UserDto userDto)
        {
            try
            {
                Order order = await _customerServices.GetOrder(id, userDto.UserId);
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                return Ok(orderDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("restaurant")]
        public async Task<IActionResult> GetRestaurantOrders([FromBody] UserDto userDto)
        {
            try
            {
                IEnumerable<Order> orders = await _restaurantServices.GetOrders(userDto.UserId);

                IEnumerable<OrderDto> ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
                return Ok(ordersDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("restaurant/{id}")]
        public async Task<IActionResult> GetRestaurantOrder(int id, [FromBody] UserDto userDto)
        {
            try
            {
                Order order = await _restaurantServices.GetOrder(id, userDto.UserId);
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
