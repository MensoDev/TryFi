using MediatR;
using TryFi.Hotspot.Application.Commands;
using TryFi.Hotspot.Domain.Entities;
using TryFi.Hotspot.Domain.Repositories;
using TryFi.Kernel.Domain.Communication.Mediator;
using TryFi.Kernel.Domain.Extensions;

namespace TryFi.Hotspot.Application.Handlers
{
    public class PlanCommandHandlers :
        IRequestHandler<RegisterPlanCommand, bool>

    {
        private readonly IPlanRepository _planRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public PlanCommandHandlers(IPlanRepository planRepository, IMediatorHandler mediatorHandler)
        {
            _planRepository = planRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(RegisterPlanCommand request, CancellationToken cancellationToken)
        {
            if (!_mediatorHandler.ValidateCommand(request)) return false;

            //TODO: implement: verification if there is a registered plan

            Plan plan = new Plan(request.Name, request.Upload, request.Download);

            //TODO: Register events on the entity

            await _planRepository.RegisterPlanAsync(plan);

            if (!await _planRepository.UnitOfWork.CommitAsync())
            {
                await _mediatorHandler.PublishNotificationAsync("RegisterPlanCommand Handler", "No Registered plan in data context");
                return false;
            }

            return true;
        }
    }
}
