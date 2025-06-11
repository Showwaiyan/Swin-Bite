namespace SwinBite.DTO
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        public FoodDto Food { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtTime { get; set; }
    }
}
