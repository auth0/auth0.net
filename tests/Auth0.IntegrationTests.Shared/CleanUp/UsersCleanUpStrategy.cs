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

        public override async Task Run()
        {
            System.Diagnostics.Debug.WriteLine("Running UsersCleanUpStrategy");
            var users = await ApiClient.Users.GetAllAsync(new GetUsersRequest(), new PaginationInfo());

            foreach (var user in users)
            {
                if (user.Email.Contains(TestingConstants.UserEmailDomain))
                {
                    Console.WriteLine($"Removing user {user.FullName}");
                    await ApiClient.Users.DeleteAsync(user.UserId);
                }
            }
        }
    }
}