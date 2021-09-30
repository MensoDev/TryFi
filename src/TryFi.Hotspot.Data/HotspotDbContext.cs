using Microsoft.EntityFrameworkCore;
using TryFi.Hotspot.Data.Extensions;
using TryFi.Hotspot.Domain.Entities;
using TryFi.Kernel.Domain.Communication.Mediator;
using TryFi.Kernel.Domain.Data;
using TryFi.Kernel.Domain.Messages;

namespace TryFi.Hotspot.Data
{
    public  class HotspotDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public HotspotDbContext(
            DbContextOptions<HotspotDbContext> options,
            IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }


        public DbSet<Plan> Plans { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotspotDbContext).Assembly);
        }


        public async Task<bool> CommitAsync()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegistrationDate") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegistrationDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegistrationDate").IsModified = false;
                }
            }

            var success = await base.SaveChangesAsync() > 0;
            if (success) await _mediatorHandler.PublishEvents(this);
            return success;
        }
    }
}
