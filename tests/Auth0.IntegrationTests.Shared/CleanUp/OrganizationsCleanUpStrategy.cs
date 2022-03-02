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

        public override async Task Run()
        {
            System.Diagnostics.Debug.WriteLine("Running OrganizationsCleanUpStrategy");
            var organizations = await ApiClient.Organizations.GetAllAsync(new PaginationInfo());

            foreach (var organization in organizations)
            {
                if (organization.Name.ToLower().StartsWith(TestingConstants.OrganizationPrefix.ToLower()))
                {
                    Console.WriteLine($"Removing organization {organization.Name}");
                    await ApiClient.Organizations.DeleteAsync(organization.Id);
                }
            }
        }
    }
}