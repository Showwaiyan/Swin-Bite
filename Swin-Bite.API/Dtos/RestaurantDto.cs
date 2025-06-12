namespace SwinBite.DTO
{
    public class RestaurantDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Rating { get; set; }
        public List<FoodDto> Menu { get; set; }
        public List<OrderDto> Orders { get; set; }
    }
}
