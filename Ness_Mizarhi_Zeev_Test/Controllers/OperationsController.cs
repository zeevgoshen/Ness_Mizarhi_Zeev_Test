using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ness_Mizarhi_Zeev_Test.Core.Models;
using Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate;
using Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Create;
using Ness_Mizarhi_Zeev_Test.Core.Operations.Queries;
using System.Net;

namespace Ness_Mizarhi_Zeev_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<CreateNewOperationResponse>> Create([FromBody] CreateNewOperationCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(null,
                new { id = result.Id },
                result
            );
        }

        [HttpPost]
        [Route("Calculate")]
        public async Task<ActionResult<CalculateOperationResponse>> Calculate([FromBody] CalculateOperationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetOperations")]
        public async Task<ActionResult<GetAllOperationsResponse>> GetOperators([FromQuery] GetAllOperationsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
