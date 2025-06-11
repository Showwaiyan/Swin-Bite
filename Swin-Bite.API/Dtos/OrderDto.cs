using SwinBite.Models;

namespace SwinBite.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime PickUpTime { get; set; }
    }
}
