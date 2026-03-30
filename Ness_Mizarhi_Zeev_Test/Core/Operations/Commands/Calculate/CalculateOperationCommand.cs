using MediatR;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    public class CalculateOperationCommand : IRequest<CalculateOperationResponse>
    {
        public int FieldA { get; set; } = default!;
        public int FieldB { get; set; } = default!;
        public string Operator { get; set; } = default!;
    }
}
