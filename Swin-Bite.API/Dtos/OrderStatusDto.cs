using SwinBite.Models;

namespace SwinBite.DTO
{
    public class OrderStatusDto
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
