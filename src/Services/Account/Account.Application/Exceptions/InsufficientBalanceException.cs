namespace Account.Application.Exceptions
{
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(decimal currentBalance)
            : base($"Insufficient balance.Your current balance is {currentBalance}")
        {
        }
    }
}
