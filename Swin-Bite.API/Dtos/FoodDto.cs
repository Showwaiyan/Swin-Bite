namespace SwinBite.DTO
{
    public class FoodDto
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId {get; set;}
        public bool IsAvailable {get; set;}
        public int PrepTime {get; set;}
    }
}
