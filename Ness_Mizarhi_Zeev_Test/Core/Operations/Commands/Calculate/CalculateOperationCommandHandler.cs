using MediatR;
using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Models;
using System.Collections.Generic;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    public class CalculateOperationCommandHandler : IRequestHandler<CalculateOperationCommand, CalculateOperationResponse>
    {
        public Task<CalculateOperationResponse> Handle(CalculateOperationCommand request, CancellationToken cancellationToken)
        {
            if (!TryCalculate(request.FieldA, request.Operator, request.FieldB, out decimal res))
                return Task.FromResult(new CalculateOperationResponse { Result = null });

            SaveCalculationToStorage(request.FieldA, request.Operator, request.FieldB, res);

            return Task.FromResult(new CalculateOperationResponse { Result = res });
        }

        private void SaveCalculationToStorage(decimal fieldA, string @operator, decimal fieldB, decimal res)
        {
            // TODO: persist calculation history to database
        }

        public static bool TryCalculate(decimal fieldA, string op, decimal fieldB, out decimal result)
        {
            try
            {
                result = 0;

                result = op switch
                {
                    "+" => fieldA + fieldB,
                    "-" => fieldA - fieldB,
                    "*" => fieldA * fieldB,
                    "/" when fieldB != 0 => fieldA / fieldB,
                    _ => throw new InvalidOperationException("Invalid operator")
                };

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
