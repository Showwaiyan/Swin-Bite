namespace SwinBite.DTO
{
    public class DrinkDto : FoodDto
    {
        public int Volume { get; set; }
        public int Temperature { get; set; }
        public bool IsCarbonated { get; set; }
        public bool HasAlcohol { get; set; }
    }
}
