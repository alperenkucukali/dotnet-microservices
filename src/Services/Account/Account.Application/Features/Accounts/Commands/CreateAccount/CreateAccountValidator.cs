using Account.Application.Constants.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.CustomerId)
                .NotEqual(Guid.Empty).WithMessage(AccountMessages.CustomerRequired);
        }
    }
}
