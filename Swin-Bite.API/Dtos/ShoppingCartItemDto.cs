namespace SwinBite.DTO
{
    public class ShoppingCartItemDto
    {
        public int ShoppingCartItemId { get; set; }
        public int Quantity { get; set; }
        public FoodDto Food { get; set; }
    }
}
