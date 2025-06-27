namespace SwinBite.Models
{
    public class Drink : Food
    {
        // Fields
        private int _volume;
        private int _temperature;
        private bool _isCarbonated;
        private bool _hasAlcohol;

        // Properties
        public int Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }
        public int Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }
        public bool IsCarbonated
        {
            get { return _isCarbonated; }
            set { _isCarbonated = value; }
        }
        public bool HasAlcohol
        {
            get { return _hasAlcohol; }
            set { _hasAlcohol = value; }
        }

        // Methods
        public override string GetDetails()
        {
            string carbonated = IsCarbonated ? "Carbonated" : "Non-Carbonated";
            string alcohol = HasAlcohol
                ? "Be aware this is non-hala due to containg alcohol"
                : "Don't worry, this is hala drink, alcohol free!.";
            return $"{carbonated} {Name} drink only {Price}$ for {Volume} Liters.Only consume at {Temperature}.{alcohol}";
        }
    }
}
