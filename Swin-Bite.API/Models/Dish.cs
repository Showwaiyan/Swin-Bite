namespace SwinBite.Models
{
    public class Dish : Food
    {
        // Fields
        private int _servingSize;
        private int _spiceLevel;
        private int _calories;
        private List<String> _ingredients;

        // Properites
        public int ServingSize
        {
            get { return _servingSize; }
            set { _servingSize = value; }
        }
        public int SpiceLevel
        {
            get { return _spiceLevel; }
            set { _spiceLevel = value; }
        }
        public int Calories
        {
            get { return _calories; }
            set { _calories = value; }
        }
        public List<String> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }

        // Methods
        public override string GetDetails()
        {
            return "";
        }
    }
}
