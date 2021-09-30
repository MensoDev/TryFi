namespace TryFi.Kernel.Domain.Messages.DomainEvents
{
    public abstract class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
