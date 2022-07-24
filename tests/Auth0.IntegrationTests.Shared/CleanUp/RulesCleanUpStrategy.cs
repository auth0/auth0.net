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

        public override async Task Run()
        {
            System.Diagnostics.Debug.WriteLine("Running RulesCleanUpStrategy");
            var rules = await ApiClient.Rules.GetAllAsync(new ManagementApi.Models.GetRulesRequest(), new PaginationInfo());

            foreach (var rule in rules)
            {
                if (rule.Name.StartsWith(TestingConstants.RulesRefix))
                {
                    Console.WriteLine($"Removing rule {rule.Name}");
                    await ApiClient.Rules.DeleteAsync(rule.Id);
                }
            }
        }
    }
}