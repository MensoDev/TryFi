namespace TryFi.Kernel.Domain.Messages.IntegrationEvents
{
    public abstract class IntegrationEvent : Event
    {
        public IntegrationEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
