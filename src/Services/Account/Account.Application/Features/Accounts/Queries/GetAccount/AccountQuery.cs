using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.Accounts.Queries.GetAccount
{
    public class AccountQuery : IRequest<GetAccountResponse>
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
