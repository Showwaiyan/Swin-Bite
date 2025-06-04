using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public class ShoppingCartItem
    {
        //Fields
        private int _shoppingCartItemId;
        private int _quantitiy;

        private int _shoppingCartId;
        private ShoppingCart _shoppingCart;

        private int _foodId;
        private Food _food;

        //Properties
        public int ShoppingCartItemId
        {
            get { return _shoppingCartItemId; }
            set { _shoppingCartItemId = value; }
        }
        public int Quantity
        {
            get { return _quantitiy; }
            set { _quantitiy = value; }
        }

        // For Many-To-Many Relationship
        [Required]
        public int ShoppingCartId
        {
            get { return _shoppingCartId; }
            set { _shoppingCartId = value; }
        }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        // For One-To-One Relationship
        [Required]
        public int FoodId
        {
            get { return _foodId; }
            set { _foodId = value; }
        }

        [ForeignKey("FoodId")]
        public Food Food
        {
            get { return _food; }
            set { _food = value; }
        }

        //Method
    }
}
