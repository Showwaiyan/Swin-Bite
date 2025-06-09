using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        private int _restaurantId;
        private Restaurant _restaurant; // Need to implement many:1 relationship
        private bool _isAvailable;
        private int _prepTime;

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

        // Many-To-One Relationship
        public int RestaurantId
        {
            get { return _restaurantId; }
            set { _restaurantId = value; }
        }

        [ForeignKey("RestaurantId")]
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

        public int PrepTime
        {
            get { return _prepTime; }
            set { _prepTime = value; }
        }

        // Method
        public string GetDetails()
        {
            return "";
        }
    }
}
