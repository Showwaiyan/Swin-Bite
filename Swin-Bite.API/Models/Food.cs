using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public abstract class Food
    {
        // Fields
        private int _foodId;
        private string _name;
        private decimal _price;
        private string _description;
        private FoodCategory _category;
        private Restaurant _restaurant; // Need to implement many:1 relationship
        private bool _isAvailable;

        // Properties
        [Key]
        public int FoodId
        {
            get { return _foodId; }
            set { _foodId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Discriminator
        [Required]
        public FoodCategory Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
        }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }

        // Method
        public string GetDetails()
        {
            return "";
        }
    }
}
