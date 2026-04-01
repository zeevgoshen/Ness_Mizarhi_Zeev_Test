using MediatR;
using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Data;
using Ness_Mizarhi_Zeev_Test.Core.Models;
using System.Collections.Generic;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Create
{
    public class CreateNewOperationCommandHandler : IRequestHandler<CreateNewOperationCommand, CreateNewOperationResponse>
    {
        private readonly IWriteDbContext _db;

        public CreateNewOperationCommandHandler(IWriteDbContext db)
        {
            _db = db;
        }

        public async Task<CreateNewOperationResponse> Handle(CreateNewOperationCommand request, CancellationToken cancellationToken)
        {
            var operation = new Operation
            {
                Operator = request.Name.Trim(),
                OperationName = request.Description?.Trim()
            };

            bool exists = await _db.Operations.AnyAsync(x => x.Operator == operation.Operator);

            if (!exists)
            {
                await _db.Operations.AddAsync(operation);
                await _db.SaveChangesAsync(cancellationToken);
            }

            return new CreateNewOperationResponse
            {
                Id = operation.OperationId,
                Operation = operation.Operator
            };
        }
    }
}
