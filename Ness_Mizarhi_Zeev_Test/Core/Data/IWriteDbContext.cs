using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Models;

namespace Ness_Mizarhi_Zeev_Test.Core.Data;

/// <summary>
/// Abstraction of the write-side DbContext.
/// Provides an EF Core implementation in the Infrastructure/Data layer.
/// </summary>
public interface IWriteDbContext
{
    DbSet<Operation> Operations { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
