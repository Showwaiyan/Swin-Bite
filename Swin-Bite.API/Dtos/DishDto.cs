namespace SwinBite.DTO
{
  public class DishDto : FoodDto
  {
    public int ServingSize {get;set;}
    public int SpiceLevel {get;set;}
    public int Calories {get;set;}
    public List<String> Ingredients {get;set;}
  }
}
