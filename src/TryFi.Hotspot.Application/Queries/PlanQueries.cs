using AutoMapper;
using TryFi.Hotspot.Application.Queries.Models;
using TryFi.Hotspot.Domain.Repositories;
using TryFi.Kernel.Domain.DomainObjects;

namespace TryFi.Hotspot.Application.Queries
{
    public class PlanQueries : IPlanQueries
    {
        private readonly IPlanRepository _planRepository;
        private readonly IMapper _mapper;

        public PlanQueries(IPlanRepository planRepository, IMapper mapper)
        {
            _planRepository = planRepository;
            _mapper = mapper;
        }

        public async ValueTask<PlanModel> GetPlanByIdAsync(Guid id)
        {
            var plan = await _planRepository.GetPlanByIdAsync(id);
            return _mapper.Map<PlanModel>(plan);
        }

        public async Task<PagingResult<PlanModel>> GetPlansPaginationAsync(int page, int itemsPerPage)
        {
            var plans = await _planRepository.GetPlansPaginationAsync(page, itemsPerPage);
            var plansModel = _mapper.Map<IEnumerable<PlanModel>>(plans);
            int totalItems = await _planRepository.GetPlansCountAsync();           

            return new PagingResult<PlanModel>(page, totalItems, itemsPerPage, plansModel);
        }

        public void Dispose()
        {
            _planRepository.Dispose();
           GC.SuppressFinalize(this);
        }
    }
}
