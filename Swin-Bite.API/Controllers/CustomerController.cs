using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwinBite.DTO;
using SwinBite.Models;
using SwinBite.Services;

namespace SwinBite.Context
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CustomerServices _customerServices;
        private readonly RestaurantServices _restaurantServices;
        private readonly FoodServices _foodServices;
        private readonly BankServices _bankServices;
        private readonly OrderServices _orderServices;

        public CustomerController(
            IMapper mapper,
            CustomerServices customerServices,
            RestaurantServices restaurantServices,
            FoodServices foodServices,
            BankServices bankServices,
            OrderServices orderServices
        )
        {
            _mapper = mapper;
            _customerServices = customerServices;
            _restaurantServices = restaurantServices;
            _foodServices = foodServices;
            _bankServices = bankServices;
            _orderServices = orderServices;
        }

        [HttpPost("cart")]
        public async Task<IActionResult> AddToCart([FromBody] CartAddDto cartAddDto)
        {
            try
            {
                int customerId = cartAddDto.UserId;
                int foodId = cartAddDto.FoodId;
                Food food = await _foodServices.GetFood(foodId);
                int quantity = cartAddDto.Quantity;

                ShoppingCartItem shoppingCartItem = await _customerServices.AddToCart(
                    customerId,
                    food,
                    quantity
                );

                ShoppingCartItemDto shoppingCartItemDto = _mapper.Map<ShoppingCartItemDto>(
                    shoppingCartItem
                );

                return Ok(shoppingCartItemDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Error Occured: {ex.Message}");
            }
        }

        [HttpGet("cart")]
        public async Task<IActionResult> CheckOut([FromBody] UserDto userDto)
        {
            try
            {
                ShoppingCart cart = await _customerServices.CheckOutCart(userDto.UserId);
                ShoppingCartDto cartDto = _mapper.Map<ShoppingCartDto>(cart);
                return Ok(cartDto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("order")]
        public async Task<IActionResult> PlaceOrder([FromBody] UserDto userDto)
        {
            try
            {
                Order order = await _customerServices.ConvertToOrder(userDto.UserId);
                Customer sender = await _customerServices.GetCustomer(order.CustomerId);
                Restaurant receiver = await _restaurantServices.GetRestaurant(order.RestaurantId);
                order.Customer = sender;
                order.Restaurant = receiver;

                if (await _bankServices.ProcessPayment(sender, receiver, order.TotalPrice))
                {
                    // Error start here

                    await _orderServices.SaveOrder(order);
                    _customerServices.ClearCart(order.Customer);
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
    }
}
