using MediatR;
using Microsoft.EntityFrameworkCore;
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
                //Description = request.Description?.Trim(),
                //CreatedAtUtc = DateTime.UtcNow
            };

            var dbSet = _db.Operations;

            if (!dbSet.ContainsAsync(operation).Result)
            {
                dbSet.AddAsync(operation);
            }
            await _db.SaveChangesAsync(cancellationToken);

            return new CreateNewOperationResponse
            {
                //Id = entity.Id,
                //Name = entity.Name,
                //Description = entity.Description,
                //CreatedAtUtc = entity.CreatedAtUtc
            };
        }
    }

    /// <summary>
    /// Abstraction of the write-side DbContext.
    /// Provide an EF Core implementation in your Infrastructure layer.
    /// </summary>
    public interface IWriteDbContext
    {
        DbSet<Operation> Operations { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
