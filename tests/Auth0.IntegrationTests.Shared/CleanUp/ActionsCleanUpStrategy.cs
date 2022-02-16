using System;
using System.Threading.Tasks;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models.Actions;
using Auth0.ManagementApi.Paging;

namespace Auth0.IntegrationTests.Shared.CleanUp
{
    public class ActionsCleanUpStrategy: CleanUpStrategy
    {
        public ActionsCleanUpStrategy(ManagementApiClient apiClient) : base(CleanUpType.Actions, apiClient)
        {
                
        }

        public override async Task Run()
        {
            System.Diagnostics.Debug.WriteLine("Running ActionsCleanUpStrategy");
            var actions = await ApiClient.Actions.GetAllAsync(new GetActionsRequest(), new PaginationInfo());

            foreach (var action in actions)
            {
                if (action.Name.StartsWith(TestingConstants.ActionPrefix))
                {
                    Console.WriteLine($"Removing action {action.Name}");
                    await ApiClient.Actions.DeleteAsync(action.Id);
                }
            }
        }
    }
}