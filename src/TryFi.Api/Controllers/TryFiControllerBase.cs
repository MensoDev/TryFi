using MediatR;
using Microsoft.AspNetCore.Mvc;
using TryFi.Kernel.Domain.Communication.Mediator;
using TryFi.Kernel.Domain.Messages.Notifications;

namespace TryFi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class TryFiControllerBase : ControllerBase
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _domainNotificationHandler;

        public TryFiControllerBase(IMediatorHandler mediatorHandler,
                                   INotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool WasSuccessfullyExecuted()
        {
            return !_domainNotificationHandler.HasNotification();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task PublishNotificationAsync(string key, string message)
        {
            await _mediatorHandler.PublishNotificationAsync(new DomainNotification(key, message));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<DomainNotification> GetDomainNotifications()
        {
            return _domainNotificationHandler.GetNotifications();
        }
    }
}
