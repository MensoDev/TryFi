using TryFi.Kernel.Domain.Communication.Mediator;
using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Hotspot.Data.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublishEvents(this IMediatorHandler mediatorHandler, HotspotDbContext context)
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Events)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediatorHandler.PublishEventAsync(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
