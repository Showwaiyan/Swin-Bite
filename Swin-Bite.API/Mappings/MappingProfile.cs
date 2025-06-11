using AutoMapper;
using SwinBite.DTO;
using SwinBite.Models;

namespace SwinBite.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Food, FoodDto>();
            CreateMap<ShoppingCart, ShoppingCartDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
        }
    }
}
