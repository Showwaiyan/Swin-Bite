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
            CreateMap<Customer, CustomerDto>();
            CreateMap<Restaurant, RestaurantDto>();

            CreateMap<Food, FoodDto>();

            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<ShoppingCartItem, ShoppingCartItemDto>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
