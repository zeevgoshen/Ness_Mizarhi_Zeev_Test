using MediatR;

namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Queries
{
    public class GetAllOperationsQueryHanlder : IRequestHandler<GetAllOperationsQuery, GetAllOperationsResponse>
    {
        public async Task<GetAllOperationsResponse> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {

            return null;
        }
    }
}
