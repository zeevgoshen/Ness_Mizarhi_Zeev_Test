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

        public async Task<CalculateOperationResponse> Handle(CalculateOperationCommand request, CancellationToken cancellationToken)
        {
            if(TryCalculate(request.FieldA, request.Operator, request.FieldB, out int res))
            {
                return new CalculateOperationResponse
                {
                    Result = res
                };
            }
            else
            {
                return new CalculateOperationResponse
                {
                    Result = null
                };
            }
        }

        public static bool TryCalculate(string a, string op, string b, out int result)
        {
            try
            {
                result = 0;

                if (!int.TryParse(a, out int num1) || !int.TryParse(b, out int num2))
                    return false;

                result = op switch
                {
                    "+" => num1 + num2,
                    "-" => num1 - num2,
                    "*" => num1 * num2,
                    "/" when num2 != 0 => num1 / num2,
                    _ => throw new InvalidOperationException("Invalid operator")
                };

                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
