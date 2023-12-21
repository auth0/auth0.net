using System;
using System.Collections.Generic;
using System.Data.Common;
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
using Xunit.Sdk;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class UserBlockTestsFixture : TestBaseFixture
    {
        public AuthenticationApiClient TestAuthenticationApiClient;
        public Connection TestConnection;
        public User TestUser;
        public const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            TestAuthenticationApiClient = new TestAuthenticationApiClient(TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // We will need a connection to add the users to...
            TestConnection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // Add a new user
            var newUserRequest = new UserCreateRequest
            {
                Connection = TestConnection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            };
            TestUser = await ApiClient.Users.CreateAsync(newUserRequest);

            

        }
        public override async Task DisposeAsync()
        {
            await ApiClient.Users.DeleteAsync(TestUser.UserId);
            await ApiClient.Connections.DeleteAsync(TestConnection.Id);
            await base.DisposeAsync();
        }
    }

    public class UserBlockTests : IClassFixture<UserBlockTestsFixture>, IAsyncLifetime
    {
        UserBlockTestsFixture fixture;

        public UserBlockTests(UserBlockTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public async Task InitializeAsync()
        {
            // Now try and sign in with a wrong password until we get "too many attempts"
            bool userBlocked = false;
            int attempts = 0;
            do
            {
                try
                {
                    attempts++;

                    await fixture.TestAuthenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                    {
                        ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                        ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                        Realm = fixture.TestConnection.Name,
                        Scope = "openid",
                        Username = fixture.TestUser.Email,
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

        [Fact(Skip = "Flakey - Run Manually")]
        public async Task Test_user_blocks_by_identifier()
        {
            // Check we should have 1 block for the user
            var userBlocks = await fixture.ApiClient.UserBlocks.GetByIdentifierAsync(fixture.TestUser.Email);
            userBlocks.BlockedFor.Should().HaveCount(1);

            // Now unblock the user
            await fixture.ApiClient.UserBlocks.UnblockByIdentifierAsync(fixture.TestUser.Email);

            // Now ensure user is not blocked anymore
            userBlocks = await fixture.ApiClient.UserBlocks.GetByIdentifierAsync(fixture.TestUser.Email);
            userBlocks.BlockedFor.Should().BeEmpty();
        }


        [Fact(Skip = "Flakey - Run Manually")]
        public async Task Test_user_blocks_by_userid()
        {
            // Check we should have 1 block for the user
            var userBlocks = await fixture.ApiClient.UserBlocks.GetByUserIdAsync(fixture.TestUser.UserId);
            userBlocks.BlockedFor.Should().HaveCount(1);

            // Now unblock the user
            await fixture.ApiClient.UserBlocks.UnblockByUserIdAsync(fixture.TestUser.UserId);

            // Now ensure user is not blocked anymore
            userBlocks = await fixture.ApiClient.UserBlocks.GetByUserIdAsync(fixture.TestUser.UserId);
            userBlocks.BlockedFor.Should().BeEmpty();
        }
    }
}