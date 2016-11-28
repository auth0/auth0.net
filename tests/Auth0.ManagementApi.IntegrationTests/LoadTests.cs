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
            var scopes = new
            {
                users = new
                {
                    actions = new string[] { "read", "create", "update", "delete" }
                },
                connections = new
                {
                    actions = new string[] { "create", "delete" }
                },
                users_app_metadata = new
                {
                    actions = new string[] { "update" }
                },
                logs = new
                {
                    actions = new string[] { "read" }
                }
            };
            string token = GenerateToken(scopes);

            var apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));

            var connection = await apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { "rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW" }
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