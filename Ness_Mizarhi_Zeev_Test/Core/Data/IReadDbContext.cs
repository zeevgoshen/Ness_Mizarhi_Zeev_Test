using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Models;

namespace Ness_Mizarhi_Zeev_Test.Core.Data;

/// <summary>
/// Abstraction of the read-side DbContext.
/// Keeps query handlers decoupled from the concrete EF Core implementation.
/// </summary>
public interface IReadDbContext
{
    DbSet<Operation> Operations { get; }
}
