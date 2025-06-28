namespace SwinBite.DTO
{
  public class SnackDto : FoodDto
  {
    public int PackageSize {get;set;}
    public bool IsHealthy {get;set;}
    public List<string> Allergens {get;set;}
  }
}
