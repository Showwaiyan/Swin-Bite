namespace SwinBite.Services
{
    public interface IValidatorServices<ValidationEventArgs>
    {
        public void Subscribe(IValidateServices<ValidationEventArgs> validateServices);
    }
}
