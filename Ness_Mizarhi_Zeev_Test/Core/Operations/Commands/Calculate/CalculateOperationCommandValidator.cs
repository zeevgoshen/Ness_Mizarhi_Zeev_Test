namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    using FluentValidation;
    public class CalculateOperationCommandValidator : AbstractValidator<CalculateOperationCommand>
    {
        public CalculateOperationCommandValidator()
        {
            RuleFor(x => x.FieldA).NotNull().WithMessage("FieldA is required");
            RuleFor(x => x.FieldB).NotNull().WithMessage("FieldB is required");
            RuleFor(x => x.Operator).NotEmpty().WithMessage("Please specify operator");
        }
    }
}
