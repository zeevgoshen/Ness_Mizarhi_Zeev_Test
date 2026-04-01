namespace Ness_Mizarhi_Zeev_Test.Core.DTOS
{
    /// <summary>
    /// Lightweight DTO for returning operation data to clients,
    /// avoiding direct exposure of the domain model.
    /// </summary>
    public class OperationDTO
    {
        public int OperationId { get; set; }
        public string Operator { get; set; } = default!;
        public string? OperationName { get; set; }
    }
}
