using MediatR;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    public class CalculateOperationCommand : IRequest<CalculateOperationResponse>
    {
        public decimal FieldA { get; set; } = default!;
        public decimal FieldB { get; set; } = default!;
        public string Operator { get; set; } = default!;
    }
}
