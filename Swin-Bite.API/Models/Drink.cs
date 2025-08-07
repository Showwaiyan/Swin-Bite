namespace SwinBite.Models
{
    public class Drink : Food
    {
        // Properties
        public int Volume { get; set; }

        public int Temperature { get; set; }

        public bool IsCarbonated { get; set; }

        public bool HasAlcohol { get; set; }

        // Methods
        public override string GetDetails()
        {
            string carbonated = IsCarbonated ? "Carbonated" : "Non-Carbonated";
            string alcohol = HasAlcohol
                ? "Be aware this is non-hala due to containing alcohol"
                : "Don't worry, this is hala drink, alcohol-free!";
            
            return $"{carbonated} {Name} drink only {Price}$ for {Volume} Liters. Only consume at {Temperature}. {alcohol}";
        }
    }
}

