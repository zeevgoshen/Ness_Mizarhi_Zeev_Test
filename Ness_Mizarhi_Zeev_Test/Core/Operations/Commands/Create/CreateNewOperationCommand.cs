using MediatR;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Create
{
    public class CreateNewOperationCommand : IRequest<CreateNewOperationResponse>
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; } = default!;
    }
}
