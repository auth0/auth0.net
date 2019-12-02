using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class UserBlockTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private AuthenticationApiClient _authenticationApiClient;
        private Connection _connection;
        private User _user;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
            _authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // We will need a connection to add the users to...
            _connection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = "Temp-Int-Test-" + MakeRandomName(),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            };
            _user = await _apiClient.Users.CreateAsync(newUserRequest);

            // Now try and sign in with a wrong password until we get "too many attempts"
            bool userBlocked = false;
            int attempts = 0;
            do
            {
                try
                {
                    attempts++;

                    await _authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                    {
                        ClientId = GetVariable("AUTH0_CLIENT_ID"),
                        ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                        Realm = _connection.Name,
                        Scope = "openid",
                        Username = _user.Email,
                        Password = "wrong_password"
                    });
                }
                catch (ErrorApiException ex)
                {
                    if (ex.ApiError.Error == "too_many_attempts")
                        userBlocked = true;
                }
            } while (!userBlocked && attempts < 20); // Add failsafe to stop if we go over 20 attempts. User should be blocked by then, but just to make sure...

        }

        public async Task DisposeAsync()
        {
            await _apiClient.Users.DeleteAsync(_user.UserId);
            await _apiClient.Connections.DeleteAsync(_connection.Id);
            _apiClient.Dispose();
        }

        [Fact]
        public async Task Test_user_blocks_by_identifier()
        {
            // Check we should have 1 block for the user
            var userBlocks = await _apiClient.UserBlocks.GetByIdentifierAsync(_user.Email);
            userBlocks.BlockedFor.Should().HaveCount(1);

            // Now unblock the user
            await _apiClient.UserBlocks.UnblockByIdentifierAsync(_user.Email);

            // Now ensure user is not blocked anymore
            userBlocks = await _apiClient.UserBlocks.GetByIdentifierAsync(_user.Email);
            userBlocks.BlockedFor.Should().BeEmpty();
        }


        [Fact]
        public async Task Test_user_blocks_by_userid()
        {
            // Check we should have 1 block for the user
            var userBlocks = await _apiClient.UserBlocks.GetByUserIdAsync(_user.UserId);
            userBlocks.BlockedFor.Should().HaveCount(1);

            // Now unblock the user
            await _apiClient.UserBlocks.UnblockByUserIdAsync(_user.UserId);

            // Now ensure user is not blocked anymore
            userBlocks = await _apiClient.UserBlocks.GetByUserIdAsync(_user.UserId);
            userBlocks.BlockedFor.Should().BeEmpty();
        }
    }
}