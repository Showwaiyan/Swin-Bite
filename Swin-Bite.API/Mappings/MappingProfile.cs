using AutoMapper;
using SwinBite.DTO;
using SwinBite.Models;

namespace SwinBite.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Restaurant, RestaurantDto>();

            CreateMap<Food, FoodDto>();
            CreateMap<Dish, DishDto>();
            CreateMap<DishDto, Dish>();
            CreateMap<Drink, DrinkDto>();
            CreateMap<DrinkDto, Drink>();
            CreateMap<Snack, SnackDto>();
            CreateMap<SnackDto, Snack>();

            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
