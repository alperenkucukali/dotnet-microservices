using Customer.Application.Constants.Messages.CustomerMessages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(CustomerMessage.EmailRequired)
                .MaximumLength(256).WithMessage(CustomerMessage.EmailExceeded)
                .EmailAddress().WithMessage(CustomerMessage.EmailIsNotValid);

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(CustomerMessage.FirstNameRequired)
                .NotNull().WithMessage(CustomerMessage.FirstNameRequired)
                .MaximumLength(128).WithMessage(CustomerMessage.FirstNameExceeded);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(CustomerMessage.LastNameRequired)
                .NotNull().WithMessage(CustomerMessage.LastNameRequired)
                .MaximumLength(128).WithMessage(CustomerMessage.LastNameExceeded);
        }
    }
}
