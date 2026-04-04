using MediatR;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    public class CalculateOperationCommand : IRequest<CalculateOperationResponse>
    {
        public decimal FieldA { get; set; }
        public decimal FieldB { get; set; }
        public string Operator { get; set; } = default!;
    }
}
