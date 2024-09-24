namespace Account.Application.Features.Accounts.Queries.GetAccount
{
    public class GetAccountResponse
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
