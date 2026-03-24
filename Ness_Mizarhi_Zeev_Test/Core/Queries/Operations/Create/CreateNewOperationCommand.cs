using MediatR;

namespace Ness_Mizarhi_Zeev_Test.Core.Queries.Operations.Create
{
    public class CreateNewOperationCommand : IRequest<CreateNewOperationResponse>
    {
        public string Name { get; set; } = default!;

        /// <summary>Optional description.</summary>
        public string? Description { get; set; }
    }
}
