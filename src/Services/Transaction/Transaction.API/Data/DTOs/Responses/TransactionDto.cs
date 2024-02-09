using EventBus.Messages.Events;

namespace Transaction.API.Data.DTOs.Responses
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
