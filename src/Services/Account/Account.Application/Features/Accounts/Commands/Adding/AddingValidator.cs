using Account.Application.Constants.Messages;
using FluentValidation;

namespace Account.Application.Features.Accounts.Commands.Adding
{
    public class AddingValidator : AbstractValidator<AddingCommand>
    {
        public AddingValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage(AccountMessages.CustomerRequired);
            RuleFor(x => x.AccountId)
                .NotEqual(Guid.Empty).WithMessage(AccountMessages.AccountRequired);
            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage(AccountMessages.AmountRequired)
                .NotNull().WithMessage(AccountMessages.AmountRequired)
                .GreaterThan(0).WithMessage(AccountMessages.AmountGreaterThanZero);
        }
    }
}
