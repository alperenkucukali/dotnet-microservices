using EventBus.Messages.Events;
using MongoDB.Bson.Serialization.Attributes;

namespace Transaction.API.Entities
{
    public class Transaction
    {
        [BsonId]
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
