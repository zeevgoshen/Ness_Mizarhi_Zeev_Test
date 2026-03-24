namespace Ness_Mizarhi_Zeev_Test.Core.Models
{
    public class Operation
    {
            public Guid Id { get; set; }
            public string Title { get; set; } = default!;
            public string? UserId { get; set; }
            public DateTime Completed { get; set; }
    }
}
