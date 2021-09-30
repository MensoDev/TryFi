using TryFi.Hotspot.Domain.Entities;
using TryFi.Kernel.Domain.Data;

namespace TryFi.Hotspot.Domain.Repositories
{
    public  interface ISubscriptionRepository : IRepository<Subscription>
    {
        ValueTask RegisterSubscriptionAsync(Subscription subscription);
        ValueTask RegsiterLoginAsync(Login login);

        ValueTask<Subscription> GetSubscriptionbyId(Guid subscriptionId);
        IQueryable<Subscription> GetSubscriptions();
        Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int page, int itemsPerPage);


        ValueTask<Login> GetLoginBySubscriptionIdAsync(Guid subscriptionId);
    }
}
