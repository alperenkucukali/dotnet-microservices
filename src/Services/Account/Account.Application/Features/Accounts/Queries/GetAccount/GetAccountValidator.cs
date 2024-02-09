using Account.Application.Constants.Messages;
using Account.Application.Features.Accounts.Commands.Withdrawing;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
