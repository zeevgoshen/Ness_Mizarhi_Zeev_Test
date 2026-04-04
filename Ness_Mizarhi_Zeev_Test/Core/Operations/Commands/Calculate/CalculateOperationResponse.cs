namespace Ness_Mizarhi_Zeev_Test.Core.Operations.Commands.Calculate
{
    public class CalculateOperationResponse
    {
        public decimal? Result {get;set;}

        // last 3 results of the same operator (top 3 like '%operator%')
        // count of same operator use since the beninging of this month
    }
}
