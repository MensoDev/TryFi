using TryFi.Kernel.Domain.Messages.Notifications;
using TryFi.Kernel.Domain.Communication.Mediator;
using TryFi.Kernel.Domain.Messages;

namespace TryFi.Kernel.Domain.Extensions
{
    public static class IMediatorHandlerCommandExtensions
    {
        public static bool ValidateCommand(this IMediatorHandler mediatorHandler, Command command)
        {
            if (command.IsValid()) return true;

            foreach (var item in command.ValidationResult.Errors)
            {
                // Domain Notification Here
                mediatorHandler.PublishNotificationAsync(
                    new DomainNotification($"{command.MessageType} - {item.PropertyName}",
                    item.ErrorMessage));
            }

            return false;
        }

        public static async Task PublishNotificationAsync(this IMediatorHandler mediatorHandler, string key, string message)
        {
            await mediatorHandler.PublishNotificationAsync(new DomainNotification(key, message));
        }
    }
}
