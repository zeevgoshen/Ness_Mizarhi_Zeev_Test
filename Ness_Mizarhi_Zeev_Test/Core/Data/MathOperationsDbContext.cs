using Microsoft.EntityFrameworkCore;
using Ness_Mizarhi_Zeev_Test.Core.Models;
using Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Create;

namespace Ness_Mizarhi_Zeev_Test.Core.Data;

public class MathOperationsDbContext : DbContext, IWriteDbContext, IReadDbContext
{
    public MathOperationsDbContext(DbContextOptions<MathOperationsDbContext> options) : base(options) { }

    public DbSet<Operation> Operations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operation>(b =>
        {
            b.HasKey(e => e.OperationId);
            b.Property(e => e.Operator).IsRequired();
            b.Property(e => e.OperationName).HasMaxLength(100);
        });
    }
}
