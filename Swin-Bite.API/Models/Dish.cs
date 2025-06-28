namespace SwinBite.Models
{
    public class Dish : Food
    {
        // Fields
        private int _servingSize;
        private int _spiceLevel;
        private int _calories;
        private List<String> _ingredients;

        //Constructor
        public Dish()
        {
          _ingredients = new List<String>();
        }

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
            string result = "";
            foreach (string item in Ingredients?? new List<string>())
            {
                result += $"{item},";
            }
            return $"{Name} containing {result.TrimEnd(',')} with {Calories} calories and {ServingSize} serving size only for {Price}$";
        }
    }
}
