using Account.Application.Features.Accounts.Queries.GetAccount;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
    }
}
