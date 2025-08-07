using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwinBite.Models
{
    public abstract class Food
    {
        [Key]
        public int FoodId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        // Computed property — not mapped by EF unless explicitly configured
        public string Description => GetDetails();

        [Required]
        public FoodCategory Category { get; set; }

        // Many-to-One Relationship
        public int RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }

        public bool IsAvailable { get; set; }

        public int PrepTime { get; set; }

        // Abstract method
        public abstract string GetDetails();
    }
}

