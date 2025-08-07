namespace SwinBite.Models
{
    public class Snack : Food
    {
        public int PackageSize { get; set; }
        public bool IsHealthy { get; set; }
        public List<string> Allergens { get; set; } = new();

        public override string GetDetails()
        {
            string allergensNotice = Allergens.Count > 0 ? " Please be aware of potential allergens." : "";
            return $"{Name} for {PackageSize}, good for desserts.{allergensNotice}";
        }
    }
}
