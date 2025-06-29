using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwinBite.DTO;
using SwinBite.Models;
using SwinBite.Services;

namespace SwinBite.Context
{
    [Route("api/deliverydrivers")]
    [ApiController]
    public class DeliveryDriverController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DeliveryDriverServices _deliveryDriverServices;
        private readonly OrderServices _orderServices;
        private readonly NotificationServices _notificationServices;

        public DeliveryDriverController(
            IMapper mapper,
            DeliveryDriverServices deliveryDriverServices,
            OrderServices orderServices,
            NotificationServices notificationServices
        )
        {
            _mapper = mapper;
            _deliveryDriverServices = deliveryDriverServices;
            _orderServices = orderServices;
            _notificationServices = notificationServices;
        }

        [HttpGet("order")]
        public async Task<IActionResult> GetAllOrders([FromBody] UserDto userDto)
        {
            try
            {
                DeliveryDriver driver = await _deliveryDriverServices.GetDeliveryDriver(
                    userDto.UserId
                );
                List<Order> validOrders = await _orderServices.GetAllDeliverableOrder();
                List<OrderDto> validOrdersDto = _mapper.Map<List<OrderDto>>(validOrders);
                return Ok(validOrdersDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("order/{id}")]
        public async Task<IActionResult> AcceptOrder(int id, [FromBody] UserDto userDto)
        {
            try
            {
                Order order = await _orderServices.GetOrderById(id);
                order = await _deliveryDriverServices.AcceptOrder(order, userDto.UserId);
                await _orderServices.UpdateOrder(order);


                _notificationServices.NotifyDeliverDriverAcceptOrder(order);

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
