using Microsoft.EntityFrameworkCore;
using TryFi.Hotspot.Domain.Entities;
using TryFi.Hotspot.Domain.Repositories;
using TryFi.Kernel.Domain.Data;
using TryFi.Kernel.Domain.DomainObjects;
using TryFi.Kernel.Domain.Extensions;

namespace TryFi.Hotspot.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {

        private HotspotDbContext _dbContext;

        public SubscriptionRepository(HotspotDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IUnitOfWork UnitOfWork => _dbContext;


        public async ValueTask RegisterSubscriptionAsync(Subscription subscription)
        {
            AssertionConcern.NotNull(subscription, "It is not possible to register a null Subscription");
            await _dbContext.Subscriptions.AddAsync(subscription);
        }

        public async ValueTask RegsiterLoginAsync(Login login)
        {
            AssertionConcern.NotNull(login, "It is not possible to register a null Login");
            await _dbContext.Logins.AddAsync(login);
        }


        public async ValueTask<Login> GetLoginBySubscriptionIdAsync(Guid subscriptionId)
        {
            return (await _dbContext.Subscriptions
                .Include(p => p.Login)
                .FirstAsync(s => s.Id == subscriptionId)).Login;
        }

        public async ValueTask<Subscription> GetSubscriptionbyId(Guid subscriptionId)
        {
            return await _dbContext.Subscriptions.FirstAsync(s => s.Id == subscriptionId);
        }

        public IQueryable<Subscription> GetSubscriptions()
        {
            return _dbContext.Subscriptions;
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptionsAsync(int page, int itemsPerPage)
        {
            return await _dbContext.Subscriptions.Pagination(page, itemsPerPage).ToListAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
