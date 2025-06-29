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
        private readonly BankServices _bankServices;
        private readonly DeliveryDriverServices _deliveryDriverServices;
        private readonly NotificationServices _notificationServices;

        public OrderController(
            IMapper mapper,
            CustomerServices customerServices,
            RestaurantServices restaruatnServices,
            OrderServices orderServices,
            BankServices bankServices,
            DeliveryDriverServices deliveryDriverServices,
            NotificationServices notificationServices
        )
        {
            _mapper = mapper;
            _customerServices = customerServices;
            _restaurantServices = restaruatnServices;
            _orderServices = orderServices;
            _bankServices = bankServices;
            _deliveryDriverServices = deliveryDriverServices;
            _notificationServices = notificationServices;
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

        [HttpPost("customer/placeorder/{type}")]
        public async Task<IActionResult> PlaceOrder([FromBody] UserDto userDto, OrderType type)
        {
            try
            {
                Order order = await _customerServices.ConvertToOrder(userDto.UserId, type);
                Customer sender = await _customerServices.GetCustomer(order.CustomerId);
                Restaurant receiver = await _restaurantServices.GetRestaurant(order.RestaurantId);
                order.Customer = sender;
                order.Restaurant = receiver;
                decimal totalPrice =
                    order.Type == OrderType.Dlivery
                        ? order.TotalPrice + (order.TotalPrice * 0.03m)
                        : order.TotalPrice;

                if (await _bankServices.ProcessPayment(sender, receiver, totalPrice))
                {
                    await _notificationServices.NotifyRestaruantForNewOrder(order);
                    await _orderServices.SaveOrder(order);
                    await _customerServices.ClearCart(order.Customer);
                    OrderDto orderDto = _mapper.Map<OrderDto>(order);
                    return Ok(orderDto);
                }

                return BadRequest("Payment is not successful.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Error Occured: {ex}");
            }
        }

        [HttpPatch("customer/{id}/pickup")]
        public async Task<IActionResult> PickUpOrder(int id, UserDto userDto)
        {
            try
            {
                Order order = await _customerServices.PickUpOrder(id, userDto.UserId);
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                await _orderServices.UpdateOrder(order);
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

        [HttpPatch("customer/{id}/cancell")]
        public async Task<IActionResult> CancellOrder(int id, UserDto userDto)
        {
            try
            {
                Order order = await _customerServices.CancellOrder(id, userDto.UserId);
                OrderDto orderDto = _mapper.Map<OrderDto>(order);
                await _orderServices.UpdateOrder(order);
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

        [HttpPatch("restaurant/{id}/{status}")]
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

                order = await _orderServices.FetchCustomerAndRestaurant(order);

                if (status == OrderStatus.Ready)
                {
                    List<DeliveryDriver> drivers =
                        await _deliveryDriverServices.GetNearByDelivery();
                    _notificationServices.NotifyDeliveryDriversForNewOrder(order, drivers);
                }

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
