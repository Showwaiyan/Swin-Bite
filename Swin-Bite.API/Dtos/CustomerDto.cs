namespace SwinBite.DTO
{
    public class CustomerDto
    {
        public int UserId { get; set; }
        public string Username {get; set;}
        public string Email {get; set;}
        public ShoppingCartDto ShoppingCart {get;set;}
    }
}
