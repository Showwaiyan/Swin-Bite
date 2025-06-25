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
        private readonly OrderServices _orderServices;

        public OrderController(
            CustomerServices customerServices,
            RestaurantServices restaruatnServices,
            OrderServices orderServices,
            IMapper mapper
        )
        {
            _customerServices = customerServices;
            _restaurantServices = restaruatnServices;
            _orderServices = orderServices;
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

        [HttpPatch("{id}/{status}")]
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PickUpOrder(int id, UserDto userDto)
        {
            try
            {
                Order order = await _customerServices.PickUpOrder(id, userDto.UserId);
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                await _orderServices.DeleteOrder(order);
                return Ok(orderDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
