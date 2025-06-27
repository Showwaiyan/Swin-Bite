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

        // [HttpGet("customers")]
        // public async Task<IActionResult> GetAllCustomers()
        // {
        //     List<Customer> customers = await _context
        //         .Customers.Include(c => c.ShoppingCart)
        //         .ThenInclude(s => s.ShoppingCartItems)
        //         .Include(c => c.Orders)
        //         .ThenInclude(o => o.OrderItems)
        //         .ToListAsync();
        //     List<CustomerDto> customersDto = _mapper.Map<List<CustomerDto>>(customers);
        //     return Ok(customersDto);
        // }

        [HttpGet("restaurants")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            List<Restaurant> restaurants = await _context
                .Restaurants.Include(r => r.Menu)
                .Include(r => r.Orders)
                .ToListAsync();
            List<RestaurantDto> restaurantDto = _mapper.Map<List<RestaurantDto>>(restaurants);
            return Ok(restaurantDto);
        }

        [HttpGet("shoppingcarts")]
        public async Task<IActionResult> GetAllShoppingCarts()
        {
            List<ShoppingCart> shoppingCarts = await _context.ShoppingCarts.ToListAsync();
            List<ShoppingCartDto> shoppingCartsDto = _mapper.Map<List<ShoppingCartDto>>(
                shoppingCarts
            );
            return Ok(shoppingCartsDto);
        }

        [HttpGet("shoppingcartitems")]
        public async Task<IActionResult> GetAllShoppingCartItems()
        {
            List<ShoppingCartItem> shoppingCartItems = await _context
                .ShoppingCartItems.Include(si => si.Food)
                .ToListAsync();
            List<ShoppingCartItemDto> shoppingCartItemsDto = _mapper.Map<List<ShoppingCartItemDto>>(
                shoppingCartItems
            );
            return Ok(shoppingCartItemsDto);
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

        [HttpPatch("updateorderstatus/{orderId}/{status}")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            if (!Enum.IsDefined(typeof(OrderStatus), status))
                return BadRequest($"There is no such status as {status}");
            Order order = await _context.Orders.FindAsync(orderId);
            if (order == null)
                return BadRequest("There is no order with this id");

            order.Status = status;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Error Occured\nError: {ex.Message}");
            }

            OrderDto orderDto = _mapper.Map<OrderDto>(order);

            return Ok(orderDto);
        }

        [HttpGet("restaurantorders/{restaurantId}")]
        public async Task<IActionResult> ViewRestaurantOrders(int restaurantId)
        {
            Restaurant restaurant = await _context
                .Restaurants.Include(r => r.Orders)
                .FirstOrDefaultAsync(r => r.UserId == restaurantId);

            if (restaurant == null)
                return BadRequest("There is no restaurant with this id.");

            List<OrderDto> orderDto = _mapper.Map<List<OrderDto>>(restaurant.Orders);
            return Ok(orderDto);
        }
    }
}
