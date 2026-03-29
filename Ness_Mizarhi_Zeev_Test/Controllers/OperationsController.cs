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

        private readonly IMediator? _mediator;

        public OperationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<CreateNewOperationResponse> Create([FromBody] CreateNewOperationCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
            //return HttpStatusCode.Created;
        }

        [HttpPost]
        [Route("calculate")]
        public async Task<CalculateOperationResponse> Calculate([FromBody] CalculateOperationCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
            //return CreatedAtAction(nameof(Calculate), new { }, result);
        }


        [HttpGet]
        [Route("GetOperations")]
        public async Task<GetAllOperationsResponse> GetOperators([FromQuery] GetAllOperationsQuery query)
        {
            var result = await _mediator.Send(query);
            return result;
        }
    }
}
