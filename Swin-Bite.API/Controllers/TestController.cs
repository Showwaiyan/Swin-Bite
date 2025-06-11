using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwinBite.Context;
using SwinBite.DTO;
using SwinBite.Models;

namespace SwinBite.Controller
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TestController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            List<CustomerDto> customersDto = _mapper.Map<List<CustomerDto>>(customers);
            return Ok(customersDto);
        }

        [HttpGet("restaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();
            return Ok(restaurants);
        }

        [HttpGet("shoppingcarts")]
        public async Task<IActionResult> GetAllShoppingCarts()
        {
            List<ShoppingCart> shoppingCarts = await _context.ShoppingCarts.ToListAsync();
            return Ok(shoppingCarts);
        }

        [HttpGet("shoppingcartitems")]
        public async Task<IActionResult> GetAllShoppingCartItems()
        {
            List<ShoppingCartItem> shoppingCartItems =
                await _context.ShoppingCartItems.ToListAsync();
            return Ok(shoppingCartItems);
        }

        [HttpGet("foods")]
        public async Task<IActionResult> GetAllFoods()
        {
            List<Food> foods = await _context.Foods.ToListAsync();

            return Ok(foods);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            List<Order> orders = await _context.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpGet("orderitems")]
        public async Task<IActionResult> GetAllOrdersItem()
        {
            List<OrderItem> orderItems = await _context.OrderItems.ToListAsync();
            return Ok(orderItems);
        }

        [HttpGet("convertcart/{shoppingCartId}")]
        public async Task<IActionResult> ConvertCart(int shoppingCartId)
        {
            ShoppingCart cart = await _context
                .ShoppingCarts.Include(c => c.ShoppingCartItems)
                .ThenInclude(i => i.Food)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync(c => c.ShoppingCartId == shoppingCartId);

            if (cart == null)
                return NotFound();

            Order order = cart.ConvertToOrder();
            if (order == null)
                throw new InvalidOperationException("Internal Processing error occured!");

            try
            {
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Error Occured\nError: {ex.Message}");
            }

            OrderDto orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }
    }
}
