using System;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class UsersCleanUpStrategy : CleanUpStrategy
    {
        public UsersCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Users, apiClient)
        {

        }

        public override async Task Run(string id)
        {
            System.Diagnostics.Debug.WriteLine("Running UsersCleanUpStrategy");
            await ApiClient.Users.DeleteAsync(id);
        }
    }
}