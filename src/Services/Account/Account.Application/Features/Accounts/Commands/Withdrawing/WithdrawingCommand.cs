using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.Accounts.Commands.Withdrawing
{
    public class WithdrawingCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
