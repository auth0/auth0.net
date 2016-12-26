using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using NUnit.Framework;

namespace Auth0.ManagementApi.IntegrationTests
{
    [TestFixture]
    public class UserBlockTests : TestBase
    {
        private ManagementApiClient apiClient;
        private AuthenticationApiClient authenticationApiClient;
        private Connection connection;
        private User user;

        [SetUp]
        public async Task SetUp()
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
                }
            };
            string token = GenerateToken(scopes);

            apiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));
            authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // We will need a connection to add the users to...
            connection = await apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { "rLNKKMORlaDzrMTqGtSL9ZSXiBBksCQW" }
            });

            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            };
            user = await apiClient.Users.CreateAsync(newUserRequest);

            // Now try and sign in with a wrong password until we get "too many attempts"
            bool userBlocked = false;
            int attempts = 0;
            do
            {
                try
                {
                    attempts++;

                    var authenticationResponse = await authenticationApiClient.AuthenticateAsync(new AuthenticationRequest
                    {
                        ClientId = GetVariable("AUTH0_CLIENT_ID"),
                        ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                        Connection = connection.Name,
                        GrantType = "password",
                        Scope = "openid",
                        Username = user.Email,
                        Password = "wrong_password"
                    });

                }
                catch (ApiException ex)
                {
                    if (ex.ApiError.Error == "too_many_attempts")
                        userBlocked = true;
                }
            } while (!userBlocked && attempts < 20); // Add failsafe to stop if we go over 20 attempts. User should be blocked by then, but just to make sure...

        }

        [TearDown]
        public async Task TearDown()
        {
            await apiClient.Users.DeleteAsync(user.UserId);
            await apiClient.Connections.DeleteAsync(connection.Id);
        }

        [Test]
        public async Task Test_user_blocks_by_identifier()
        {
            // Check we should have 1 block for the user
            var userBlocks = await apiClient.UserBlocks.GetByIdentifierAsync(user.Email);
            userBlocks.BlockedFor.Should().HaveCount(1);

            // Now unblock the user
            await apiClient.UserBlocks.UnblockByIdentifierAsync(user.Email);

            // Now ensure user is not blocked anymore
            userBlocks = await apiClient.UserBlocks.GetByIdentifierAsync(user.Email);
            userBlocks.BlockedFor.Should().BeEmpty();
        }


        [Test]
        public async Task Test_user_blocks_by_userid()
        {
            // Check we should have 1 block for the user
            var userBlocks = await apiClient.UserBlocks.GetByUserIdAsync(user.UserId);
            userBlocks.BlockedFor.Should().HaveCount(1);

            // Now unblock the user
            await apiClient.UserBlocks.UnblockByUserIdAsync(user.UserId);

            // Now ensure user is not blocked anymore
            userBlocks = await apiClient.UserBlocks.GetByUserIdAsync(user.UserId);
            userBlocks.BlockedFor.Should().BeEmpty();
        }
    }
}