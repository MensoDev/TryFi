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


        public async Task<IEnumerable<Plan>> GetPlansAsync(int page, int itemsPerPage)
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

        //TODO: Esse codigo ser migrado para um lugar mais adequado onde possa ser melhor reutilizado pela aplicação

        //private static int GetTotalPages(int itemsPerPage, int totalItems)
        //{
        //    double total = (double)totalItems / (double)itemsPerPage;
        //    double totalPages = Math.Ceiling(total);
        //    return (int)totalPages;
        //}

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
