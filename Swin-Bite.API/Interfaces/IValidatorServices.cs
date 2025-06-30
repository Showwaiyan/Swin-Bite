namespace SwinBite.Interface
{
    public interface IValidatorServices<ValidationEventArgs>
    {
        public void Subscribe(IValidateServices<ValidationEventArgs> validateServices);
    }
}
