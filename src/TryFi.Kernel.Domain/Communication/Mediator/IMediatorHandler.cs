using TryFi.Kernel.Domain.Messages;
using TryFi.Kernel.Domain.Messages.DomainEvents;
using TryFi.Kernel.Domain.Messages.Notifications;

namespace TryFi.Kernel.Domain.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<bool> SendCommandAsync<T>(T comando) where T : Command;
        Task PublishEventAsync<T>(T eventArgs) where T : Event;
        Task PublishDomainEventAsync<T>(T eventArgs) where T : DomainEvent;

        Task PublishNotificationAsync<T>(T notificacao) where T : DomainNotification;
    }
}
