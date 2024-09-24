using Account.Domain.Common;

namespace Account.Domain.Entities
{
    public class Account : EntityBase
    {
        public Account()
        {

        }
        public Account(Guid id, Guid customerId, decimal balance)
        {
            Id = id;
            CustomerId = customerId;
            Balance = balance;
        }

        public Guid CustomerId { get; set; }
        public decimal Balance { get; set; }
    }
}
