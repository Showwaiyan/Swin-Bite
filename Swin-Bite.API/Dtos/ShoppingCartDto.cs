namespace SwinBite.DTO
{
    public class ShoppingCartDto
    {
        public int ShoppingCartId { get; set; }
        public List<ShoppingCartItemDto> ShoppingCartItems { get; set; }
    }
}
