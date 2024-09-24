using MediatR;

namespace Account.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
    }
}
