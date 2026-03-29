using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ness_Mizarhi_Zeev_Test.Core.Models;
using Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Create;

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
        public async Task<ActionResult<CreateNewOperationResponse>> Create([FromBody] CreateNewOperationCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new {  }, result);
        }


        [HttpGet(Name = "GetOperations")]
        public IEnumerable<Operation> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Operation
            {
            })
            .ToArray();
        }
    }
}
