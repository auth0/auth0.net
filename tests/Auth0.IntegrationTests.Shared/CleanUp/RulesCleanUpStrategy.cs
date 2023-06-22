using System;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Paging;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class RulesCleanUpStrategy : CleanUpStrategy
    {
        public RulesCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Rules, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running RulesCleanUpStrategy");
            await ApiClient.Rules.DeleteAsync(id);   
        }
    }
}