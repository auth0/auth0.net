using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0.Core.Exceptions;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class UserBlockTests : ManagementTestBase, IAsyncLifetime
    {
        private AuthenticationApiClient _authenticationApiClient;
        private Connection _connection;
        private User _user;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
            _authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // We will need a connection to add the users to...
            _connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = _connection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            _user = await ApiClient.Users.CreateAsync(newUserRequest);

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
                catch (RateLimitApiException)
                {
                    await Task.Delay(1000);
                }
                catch (ErrorApiException ex)
                {
                    if (ex.ApiError.Error == "too_many_attempts")
                        userBlocked = true;
                }
            } while (!userBlocked && attempts < 20); // Add failsafe to stop if we go over 20 attempts. User should be blocked by then, but just to make sure...

        }

        public override async Task DisposeAsync()
        {
            await ApiClient.Users.DeleteAsync(_user.UserId);
            await ApiClient.Connections.DeleteAsync(_connection.Id);
            await CleanupAndDisposeAsync();
        }

        [Fact]
        public async Task Test_user_blocks_by_identifier()
        {
            // Check we should have 1 block for the user
            var userBlocks = await ApiClient.UserBlocks.GetByIdentifierAsync(_user.Email);
            userBlocks.BlockedFor.Should().HaveCount(1);

            // Now unblock the user
            await ApiClient.UserBlocks.UnblockByIdentifierAsync(_user.Email);

            // Now ensure user is not blocked anymore
            userBlocks = await ApiClient.UserBlocks.GetByIdentifierAsync(_user.Email);
            userBlocks.BlockedFor.Should().BeEmpty();
        }


        [Fact]
        public async Task Test_user_blocks_by_userid()
        {
            // Check we should have 1 block for the user
            var userBlocks = await ApiClient.UserBlocks.GetByUserIdAsync(_user.UserId);
            userBlocks.BlockedFor.Should().HaveCount(1);

            // Now unblock the user
            await ApiClient.UserBlocks.UnblockByUserIdAsync(_user.UserId);

            // Now ensure user is not blocked anymore
            userBlocks = await ApiClient.UserBlocks.GetByUserIdAsync(_user.UserId);
            userBlocks.BlockedFor.Should().BeEmpty();
        }
    }
}