using System;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Paging;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class OrganizationsCleanUpStrategy : CleanUpStrategy
    {
        public OrganizationsCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Organizations, apiClient)
        {

        }
 
        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running OrganizationsCleanUpStrategy");

            await ApiClient.Organizations.DeleteAsync(id); 
        }
    }
}