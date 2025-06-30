using SwinBite.Models;
using SwinBite.Reposiroties;
using SwinBite.Interface;

namespace SwinBite.Services
{
    public class BankServices : IValidateServices<ValidationEventArgs>
    {
        public event EventHandler<ValidationEventArgs> OnValidate;
        private readonly BankRepository _repo;

        public BankServices(BankRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> ProcessPayment(User sender, User receiver, decimal amount)
        {
            if (sender.BankAccount.Balance < amount)
                throw new InvalidOperationException("You don't have cash for this order");

            IValidatorServices<ValidationEventArgs> bankValidator = new BankValidatorServices();
            bankValidator.Subscribe(this);

            string errorMessage;
            if (Validate(sender, out errorMessage))
            {
                throw new InvalidOperationException(errorMessage);
            }
            if (Validate(receiver, out errorMessage))
            {
                throw new InvalidOperationException(errorMessage);
            }

            sender.BankAccount.ProcessPayment(-amount);
            await _repo.UpdateBankAccount(sender.BankAccount);

            receiver.BankAccount.ProcessPayment(amount);
            await _repo.UpdateBankAccount(receiver.BankAccount);

            return true;
        }

        public bool Validate(object user, out string errorMessage)
        {
            ValidationEventArgs args = new ValidationEventArgs();
            OnValidate?.Invoke(user, args);
            if (!args.IsValid)
            {
                errorMessage = args.ErrorMessage;
                return false;
            }
            errorMessage = null;
            return true;
        }
    }
}
