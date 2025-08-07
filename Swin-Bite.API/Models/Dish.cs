
namespace SwinBite.Models
{
    public class Dish : Food
    {
        // Constructor
        public Dish()
        {
            Ingredients = new List<string>();
        }

        // Properties
        public int ServingSize { get; set; }

        public int SpiceLevel { get; set; }

        public int Calories { get; set; }

        public List<string> Ingredients { get; set; }

        // Methods
        public override string GetDetails()
        {
            string result = "";

            foreach (string item in Ingredients ?? new List<string>())
            {
                result += $"{item},";
            }

            return $"{Name} containing {result.TrimEnd(',')} with {Calories} calories and {ServingSize} serving size only for {Price}$";
        }
    }
}
