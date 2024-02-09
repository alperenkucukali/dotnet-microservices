using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class AccountTransactionEvent : IntegrationBaseEvent
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
    }
}