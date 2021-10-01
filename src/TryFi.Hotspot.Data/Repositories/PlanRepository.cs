using Microsoft.EntityFrameworkCore;
using TryFi.Hotspot.Domain.Entities;
using TryFi.Hotspot.Domain.Repositories;
using TryFi.Kernel.Domain.Data;
using TryFi.Kernel.Domain.DomainObjects;
using TryFi.Kernel.Domain.Extensions;

namespace TryFi.Hotspot.Data.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly HotspotDbContext _dbContext;

        public PlanRepository(HotspotDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public IUnitOfWork UnitOfWork => _dbContext;

        

        public async ValueTask RegisterPlanAsync(Plan plan)
        {
            AssertionConcern.NotNull(plan, "It is not possible to register a null Plan");
            await _dbContext.Plans.AddAsync(plan);
        }


        public async Task<IEnumerable<Plan>> GetPlansPaginationAsync(int page, int itemsPerPage)
        {
            return await _dbContext
                .Plans
                .AsNoTracking()
                .Pagination(page, itemsPerPage, p => p.RegistrationDate)
                .ToListAsync();            
        }

        public  IQueryable<Plan> GetPlans()
        {
            return _dbContext.Plans.AsNoTracking().AsQueryable();
        }

        public async ValueTask<Plan> GetPlanByIdAsync(Guid planId)
        {
            return await _dbContext.Plans.FirstOrDefaultAsync(p => p.Id == planId);
        }

        public async ValueTask<int> GetPlansCountAsync()
        {
            return await _dbContext.Plans.CountAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}
