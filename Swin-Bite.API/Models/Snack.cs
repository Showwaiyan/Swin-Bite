namespace SwinBite.Models
{
    public class Snack : Food
    {
        // Fields
        private int _packageSize;
        private bool _isHealthy;
        private List<string> _allergens;

        // Properties
        public int PackageSize
        {
            get { return _packageSize; }
            set { _packageSize = value; }
        }
        public bool IsHealthy
        {
            get { return _isHealthy; }
            set { _isHealthy = value; }
        }
        public List<string> Allergens
        {
            get { return _allergens; }
            set { _allergens = value; }
        }

        // Methods
        public override string GetDetails()
        {
            string allergens = Allergens.Count() > 0 ? "Please aware for allergics reaction" : "";
            return $"{Name} for {PackageSize}, good for desserts.{allergens}";
        }
    }
}
