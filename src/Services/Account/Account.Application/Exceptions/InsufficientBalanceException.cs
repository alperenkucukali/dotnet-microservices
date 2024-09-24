namespace Account.Application.Exceptions
{
    public class InsufficientBalanceException(decimal currentBalance)
        : ApplicationException($"Insufficient balance.Your current balance is {currentBalance}");
}
