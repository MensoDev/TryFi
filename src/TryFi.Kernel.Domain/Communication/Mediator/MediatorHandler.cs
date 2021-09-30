using MediatR;
using TryFi.Kernel.Domain.Messages;
using TryFi.Kernel.Domain.Messages.DomainEvents;
using TryFi.Kernel.Domain.Messages.Notifications;

namespace TryFi.Kernel.Domain.Communication.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishDomainEventAsync<T>(T eventArgs) where T : DomainEvent
        {
            await _mediator.Publish(eventArgs);
        }

        public async Task PublishEventAsync<T>(T eventArgs) where T : Event
        {
            await _mediator.Publish(eventArgs);
        }

        public async Task PublishNotificationAsync<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }

        public async Task<bool> SendCommandAsync<T>(T cmd) where T : Command
        {
            return await _mediator.Send(cmd);
        }
    }
}
