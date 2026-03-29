using MediatR;
using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Data;
using Ness_Mizarhi_Zeev_Test.Core.Models;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Queries
{
    public class GetAllOperationsQueryHanlder : IRequestHandler<GetAllOperationsQuery, GetAllOperationsResponse>
    {
        private readonly MathOperationsDbContext _db;

        public GetAllOperationsQueryHanlder(MathOperationsDbContext db)
        {
            _db = db;
        }
        public async Task<GetAllOperationsResponse> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {
            return new GetAllOperationsResponse
            {
                Operators = await _db.Operations.ToListAsync()
            };
        }
    }
}
