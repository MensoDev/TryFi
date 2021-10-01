using TryFi.Kernel.Domain.Messages.Notifications;
using TryFi.Models;

namespace TryFi.Api.Extensions
{
    public static class EnumerationDomainNotificationExtensions
    {
        public static ApiResult CreateApiResult(this IEnumerable<DomainNotification> notifications, bool success)
        {
            var result = new ApiResult(success);
            foreach (var notification in notifications)
            {
                result.Errors.Add(new ApiError(notification.Key, notification.Value, notification.MessageType));
            }

            return result;
        }
    }
}
