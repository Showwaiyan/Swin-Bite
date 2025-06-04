using System.ComponentModel.DataAnnotations;

namespace SwinBite.Models
{
    public class Customer : User
    {
        // Fields
        private ShoppingCart _shoppingCart;
        private List<Order> _order;

        // Properties
        [Required]
        public ShoppingCart ShoppingCart // One-to-One relationship
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public List<Order> Order // One-to-Many relationship (! Need to implement later)
        {
            get { return _order; }
            set { _order = value; }
        }

        // Methods
        public void AddToCart() { }

        public bool PlaceOrder()
        {
            return true;
        }

        public List<Restaurant> BrowseRestaurants()
        {
            return new List<Restaurant> { };
        }

        public List<Food> ViewMenu(int restaurantId)
        {
            return new List<Food> { };
        }
    }
}
