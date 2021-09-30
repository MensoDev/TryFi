using TryFi.Hotspot.Domain.Entities;
using TryFi.Kernel.Domain.Data;
using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Hotspot.Domain.Repositories
{
    public  interface IPlanRepository : IRepository<Plan>
    {

        ValueTask RegisterPlanAsync(Plan plan);

        Task<PagingResult<Plan>> GetPlansAsync();
        Task<PagingResult<Plan>> GetPlansAsync(Paging<Plan> paging);

    }
}
