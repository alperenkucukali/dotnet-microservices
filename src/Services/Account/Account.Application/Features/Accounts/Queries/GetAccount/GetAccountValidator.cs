using Account.Application.Constants.Messages;
using FluentValidation;

namespace Account.Application.Features.Accounts.Queries.GetAccount
{
    public class GetAccountValidator : AbstractValidator<AccountQuery>
    {
        public GetAccountValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage(AccountMessages.CustomerRequired);
            RuleFor(x => x.AccountId)
                .NotEqual(Guid.Empty).WithMessage(AccountMessages.AccountRequired);
        }
    }
}
