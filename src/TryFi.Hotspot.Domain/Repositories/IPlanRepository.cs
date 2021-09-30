using TryFi.Hotspot.Domain.Entities;
using TryFi.Kernel.Domain.Data;

namespace TryFi.Hotspot.Domain.Repositories
{
    public  interface IPlanRepository : IRepository<Plan>
    {

        ValueTask RegisterPlanAsync(Plan plan);

        Task<IEnumerable<Plan>> GetPlansAsync(int page, int itemsPerPage);
        IQueryable<Plan> GetPlans();

    }
}
