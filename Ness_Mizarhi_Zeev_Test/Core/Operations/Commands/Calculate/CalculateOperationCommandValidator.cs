namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    using FluentValidation;
    public class CalculateOperationCommandValidator : AbstractValidator<CalculateOperationCommand>
    {
        private static readonly string[] ValidOperators = ["+", "-", "*", "/"];
        public CalculateOperationCommandValidator()
        {
            // FieldA and FieldB are decimal — any value including 0 is valid, no rules needed.
            // Operator must be present and one of the supported symbols.
            RuleFor(x => x.Operator)
                .NotEmpty().WithMessage("Please specify an operator.")
                .Must(op => ValidOperators.Contains(op))
                .WithMessage($"Operator must be one of: {string.Join(", ", ValidOperators)}");
        }
    }
}
