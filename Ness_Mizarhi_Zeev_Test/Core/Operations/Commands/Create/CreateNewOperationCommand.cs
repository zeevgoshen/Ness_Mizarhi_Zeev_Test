using MediatR;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Create
{
    public class CreateNewOperationCommand : IRequest<CreateNewOperationResponse>
    {
        public string Name { get; set; } = default!;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }
    }
}
