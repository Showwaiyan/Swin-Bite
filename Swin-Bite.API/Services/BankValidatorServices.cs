using SwinBite.Models;
using SwinBite.Interface;

namespace SwinBite.Services
{
    public class BankValidatorServices : IValidatorServices<ValidationEventArgs>
    {
        public void Subscribe(IValidateServices<ValidationEventArgs> validateServices)
        {
            validateServices.OnValidate += AccountValidate;
            validateServices.OnValidate += AuthenticationValidate;
        }

        private void AccountValidate(object sender, ValidationEventArgs args)
        {
            User user = sender as User;
            if (user.BankAccount == null)
            {
                args.IsValid = false;
                args.ErrorMessage = "You don't have bank account, please connect your wellet.";
            }
        }

        private void AuthenticationValidate(object sender, ValidationEventArgs args)
        {
            User user = sender as User;
            if (!user.IsAuthenticated)
            {
                args.IsValid = false;
                args.ErrorMessage = "You don't have any authorized, please verify yourself.";
            }
        }
    }
}
