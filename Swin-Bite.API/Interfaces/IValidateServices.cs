namespace SwinBite.Interface
{
    public interface IValidateServices<ValidationEventArgs>
    {
        public event EventHandler<ValidationEventArgs> OnValidate;
        public bool Validate(object sender, out string errorMessage);
    }
}
