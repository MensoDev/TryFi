using TryFi.Hotspot.Application.Queries.Models;
using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Hotspot.Application.Queries
{
    public interface IPlanQueries : IDisposable
    {
        ValueTask<PlanModel> GetPlanByIdAsync(Guid id);
        Task<PagingResult<PlanModel>> GetPlansPaginationAsync(int page, int itemsPerPage);
        
    }
}
