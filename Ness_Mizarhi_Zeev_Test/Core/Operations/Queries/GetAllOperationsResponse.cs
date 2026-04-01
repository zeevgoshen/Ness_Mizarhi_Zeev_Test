using Ness_Mizarhi_Zeev_Test.Core.Models;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Queries
{
    public class GetAllOperationsResponse
    {
        public IEnumerable<Operation> Operators { get; set; } = [];
    }
}
