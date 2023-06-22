using System;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class HooksCleanUpStrategy : CleanUpStrategy
    {
        public HooksCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Hooks, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running HooksCleanUpStrategy");
            
            await ApiClient.Hooks.DeleteAsync(id);
                
        }
    }
}