namespace SwinBite.Interfaces
{
    public interface IValidatorServices<ValidationEventArgs>
    {
        public void Subscribe(IValidateServices<ValidationEventArgs> validateServices);
    }
}
