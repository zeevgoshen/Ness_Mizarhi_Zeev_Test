namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    using FluentValidation;
    public class CalculateOperationCommandValidator : AbstractValidator<CalculateOperationCommand>
    {
        private static readonly string[] ValidOperators = ["+", "-", "*", "/"];
        public CalculateOperationCommandValidator()
        {
            RuleFor(x => x.FieldA)
                .InclusiveBetween(int.MinValue, int.MaxValue)
                .WithMessage("FieldA must be a valid integer.");

            RuleFor(x => x.FieldB)
                .InclusiveBetween(int.MinValue, int.MaxValue)
                .WithMessage("FieldB must be a valid integer.");

            RuleFor(x => x.Operator)
                .NotEmpty().WithMessage("Please specify an operator.")
                .Must(op => ValidOperators.Contains(op))
                .WithMessage($"Operator must be one of: {string.Join(", ", ValidOperators)}");
        }
    }
}
