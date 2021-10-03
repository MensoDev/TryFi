using MediatR;
using Microsoft.AspNetCore.Mvc;
using TryFi.Api.Extensions;
using TryFi.Hotspot.Application.Commands;
using TryFi.Hotspot.Application.Queries;
using TryFi.Kernel.Domain.Communication.Mediator;
using TryFi.Kernel.Domain.Messages.Notifications;
using TryFi.Models;
using TryFi.Models.Hotspot;

namespace TryFi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : TryFiControllerBase
    {

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IPlanQueries _planQueries;
        private readonly ILogger<PlansController> _logger;

        public PlansController(
            IMediatorHandler mediatorHandler, 
            INotificationHandler<DomainNotification> domainNotificationHandler, 
            IPlanQueries planQueries, 
            ILogger<PlansController> logger) : base(mediatorHandler, domainNotificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _planQueries = planQueries;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult<ApiResult>> RegisterPlanAsync([FromBody] RegisterPlanCommandModel model)
        {           

            var command = new RegisterPlanCommand(model.Name, model.Upload, model.Download);
            var success = await _mediatorHandler.SendCommandAsync(command);

            if (!success)
            {
                ApiResult result = GetDomainNotifications().CreateApiResult(success);
                result.Errors.ForEach(p => _logger.LogError(p.ToString()));
                return result;
            }

            return Ok(new ApiResult(success));
        }

        
    }
}
