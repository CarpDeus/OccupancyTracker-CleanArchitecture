using MediatR;
using Microsoft.AspNetCore.Mvc;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.ChangeLocationCurrentOccupancy;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Queries.GetLocationCurrentOccupancy;
using SecureScalableSolutions.OccupancyTracker.Application.Features.OccupancyLog.Commands.CreateOccupancyLog;

namespace SecureScalableSolutions.OccupancyTracker.Counter.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class OccupancyLogController : Controller
    {
        private readonly IMediator _mediator;
        public OccupancyLogController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("logoccupancychange", Name ="LogOccupanyChange")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CreateOccupancyLogCommandResponse>> Log([FromBody] CreateOccupancyLogCommand createOccupancyLogCommand)
        {
            var response = await _mediator.Send(createOccupancyLogCommand);
            return Ok(response);
        }

        [HttpGet("currentoccupancy", Name ="GetLocationCurrentOccupancy")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetLocationCurrentOccupancyCommandResponse>> GetLocationCurrentOccupancy(string  locationSqid)
        {
            GetLocationCurrentOccupancyCommand getLocationCurrentOccupancyCommand = new GetLocationCurrentOccupancyCommand(locationSqid);
            var response = await _mediator.Send(getLocationCurrentOccupancyCommand);
            return Ok(response);
        }
    }
}
