using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SwinBite.DTO;
using SwinBite.Interface;
using SwinBite.Models;
using SwinBite.Services;

namespace SwinBite.Context
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerServices _customerServices;
        private readonly FoodServices _foodServices;

        public CustomerController(
            IMapper mapper,
            ICustomerServices customerServices,
            FoodServices foodServices
        )
        {
            _mapper = mapper;
            _customerServices = customerServices;
            _foodServices = foodServices;
        }

        [HttpPost("cart")]
        public async Task<IActionResult> AddToCart([FromBody] CartOperationDto cartOperationDto)
        {
            try
            {
                int customerId = cartOperationDto.UserId;
                int foodId = cartOperationDto.FoodId;
                Food food = await _foodServices.GetFood(foodId);
                int quantity = cartOperationDto.Quantity;

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

        [HttpPatch("cart")]
        public async Task<IActionResult> RemoveFromCart(
            [FromBody] CartOperationDto cartOperationDto
        )
        {
            try
            {
                int customerId = cartOperationDto.UserId;
                int foodId = cartOperationDto.FoodId;
                Food food = await _foodServices.GetFood(foodId);

                ShoppingCartItem shoppingCartItem = await _customerServices.RemoveFromCart(
                    customerId,
                    food
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
            catch (InvalidOperationException ex)
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
    }
}
