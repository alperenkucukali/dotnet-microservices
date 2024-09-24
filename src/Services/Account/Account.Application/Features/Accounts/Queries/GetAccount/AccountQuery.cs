using MediatR;

namespace Account.Application.Features.Accounts.Queries.GetAccount
{
    public class AccountQuery : IRequest<GetAccountResponse>
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
