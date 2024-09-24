namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent(Guid id, DateTime createDate)
        {
        public IntegrationBaseEvent() : this(Guid.NewGuid(), DateTime.UtcNow)
        {
        }

        public Guid Id { get; private set; } = id;

        public DateTime CreationDate { get; private set; } = createDate;
        }
}