using MediatR;
using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Models;
using System.Collections.Generic;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    public class CalculateOperationCommandHandler : IRequestHandler<CalculateOperationCommand, CalculateOperationResponse>
    {
        //private readonly IWriteDbContext _db;

        //public CalculateOperationCommandHandler(IWriteDbContext db)
        //{
        //    _db = db;
        //}

        public Task<CalculateOperationResponse> Handle(CalculateOperationCommand request, CancellationToken cancellationToken)
        {
            if (!TryCalculate(request.FieldA, request.Operator, request.FieldB, out int res))
                return Task.FromResult(new CalculateOperationResponse
                {
                    Result = -9999
                });

            SaveCalculationToStorage(request.FieldA, request.Operator, request.FieldB, res);

            return Task.FromResult(new CalculateOperationResponse
            {
                Result = res
            });
        }

        private void SaveCalculationToStorage(int fieldA, string @operator, int fieldB, int res)
        {
            //throw new NotImplementedException();
        }

        public static bool TryCalculate(int fieldA, string op, int fieldB, out int result)
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
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Abstraction of the write-side DbContext.
    /// Provide an EF Core implementation in your Infrastructure layer.
    /// </summary>
    //public interface IWriteDbContext
    //{
    //    DbSet<Operation> Operations { get; }
    //    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    //}
}
