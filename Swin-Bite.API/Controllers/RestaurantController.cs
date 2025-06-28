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
        private readonly FoodServices _foodServices;

        public RestaurantController(
            RestaurantServices restaurantServices,
            FoodServices foodServices,
            IMapper mapper
        )
        {
            _restaurantServices = restaurantServices;
            _foodServices = foodServices;
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

        [HttpPost("{id}/dish")]
        public async Task<IActionResult> AddDishToMenu(int id, [FromBody] DishDto foodDto)
        {
            try
            {
                Dish dish = _mapper.Map<Dish>(foodDto);
                Food dishAdded = await _restaurantServices.AddFoodToMenu(id, dish);

                if (!(await _foodServices.AddMenu(dishAdded))) throw new InvalidOperationException("Can't create menu");

                DishDto dishDto = _mapper.Map<DishDto>(dishAdded);
                return Ok(dishDto);
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

        [HttpPost("{id}/drink")]
        public async Task<IActionResult> AddDrinkToMenu(int id, [FromBody] DrinkDto foodDto)
        {
            try
            {
                Drink drink = _mapper.Map<Drink>(foodDto);
                Food drinkAdded = await _restaurantServices.AddFoodToMenu(id, drink);

                if (!(await _foodServices.AddMenu(drinkAdded))) throw new InvalidOperationException("Can't create menu");

                DrinkDto drinkDto = _mapper.Map<DrinkDto>(drinkAdded);
                return Ok(drinkDto);
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

        [HttpPost("{id}/snack")]
        public async Task<IActionResult> AddSnackToMenu(int id, [FromBody] SnackDto foodDto)
        {
            try
            {
                Snack snack = _mapper.Map<Snack>(foodDto);
                Food snackAdded = await _restaurantServices.AddFoodToMenu(id, snack);

                if (!(await _foodServices.AddMenu(snackAdded))) throw new InvalidOperationException("Can't create menu");

                SnackDto snackDto = _mapper.Map<SnackDto>(snackAdded);
                return Ok(snackDto);
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
