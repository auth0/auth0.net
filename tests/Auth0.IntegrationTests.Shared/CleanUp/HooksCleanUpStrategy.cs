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

        public override async Task Run()
        {
            System.Diagnostics.Debug.WriteLine("Running HooksCleanUpStrategy");
            var hooks = await ApiClient.Hooks.GetAllAsync(new GetHooksRequest(), new PaginationInfo());

            foreach (var hook in hooks)
            {
                if (hook.Name.StartsWith(TestingConstants.HooksPrefix))
                {
                    Console.WriteLine($"Removing hook {hook.Name}");
                    await ApiClient.Hooks.DeleteAsync(hook.Id);
                }
            }
        }
    }
}