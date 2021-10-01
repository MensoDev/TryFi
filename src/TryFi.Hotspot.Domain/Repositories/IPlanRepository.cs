using TryFi.Hotspot.Domain.Entities;
using TryFi.Kernel.Domain.Data;

namespace TryFi.Hotspot.Domain.Repositories
{
    public  interface IPlanRepository : IRepository<Plan>
    {

        ValueTask RegisterPlanAsync(Plan plan);


        ValueTask<Plan> GetPlanByIdAsync(Guid planId);

        Task<IEnumerable<Plan>> GetPlansPaginationAsync(int page, int itemsPerPage);
        IQueryable<Plan> GetPlans();

        ValueTask<int> GetPlansCountAsync();

    }
}
