using MediatR;
using System.Collections.Generic;

namespace Ness_Mizarhi_Zeev_Test.Core.Queries.Operations.Create
{
    public class CreateNewOperationCommandHandler : IRequestHandler<CreateNewOperationCommand, CreateNewOperationResponse>
    {
        //private readonly IWriteDbContext _db;

        public CreateNewOperationCommandHandler(/*IWriteDbContext db*/)
        {
            //_db = db;
        }

        public async Task<CreateNewOperationResponse> Handle(CreateNewOperationCommand request, CancellationToken cancellationToken)
        {
            //var entity = new Record
            //{
            //    Id = Guid.NewGuid(),
            //    Name = request.Name.Trim(),
            //    Description = request.Description?.Trim(),
            //    CreatedAtUtc = DateTime.UtcNow
            //};

            //_db.Records.Add(entity);
            //await _db.SaveChangesAsync(cancellationToken);

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
        //DbSet<Record> Records { get; }
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
