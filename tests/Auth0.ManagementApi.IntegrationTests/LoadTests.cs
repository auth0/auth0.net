using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using NUnit.Framework;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class LoadTests : TestBase
    {
        [Test, Explicit]
        public async Task LoadTestAddUsers()
        {
            string token = await GenerateManagementApiToken();

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            var connection = await apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });


            // Add a new user
            for (int i = 1; i <= 200; i++)
            {
                TestContext.Out.WriteLine($"Adding user {i}");

                var newUserRequest = new UserCreateRequest
                {
                    Connection = connection.Name,
                    Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                    EmailVerified = true,
                    Password = "password"
                };
                await apiClient.Users.CreateAsync(newUserRequest);
            }

            await apiClient.Connections.DeleteAsync(connection.Id);
        }
    }
}