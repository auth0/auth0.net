using Auth0.AuthenticationApi.Models;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.IntegrationTests.Testing;
using Auth0.IntegrationTests.Shared.CleanUp;
using Xunit;
using System.Collections.Generic;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class AuthenticationTestsFixture : TestBaseFixture
    {
        public AuthenticationApiClient TestAuthenticationApiClient;
        public Connection TestConnection;
        public User TestUser;
        public User TestPlusUser;
        public User TestUserInDefaultDirectory;
        public string TestPassword = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            var tenantSettings = await ApiClient.TenantSettings.GetAsync();

            if (string.IsNullOrEmpty(tenantSettings.DefaultDirectory))
            {
                throw new Exception("Tests require a tenant with a Default Directory selected.\r\n" +
                    "Enable OAuth 2.0 API Authorization under Account Settings | General and " +
                    "select a Default Directory under Account Settings | General");
            }

            // We will need a connection to add the users to...
            TestConnection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] { TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            TrackIdentifier(CleanUpType.Connections, TestConnection.Id);

            // And add a dummy user to test against
            TestUser = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = TestConnection.Name,
                Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = TestPassword
            });

            TrackIdentifier(CleanUpType.Users, TestUser.UserId);

            // Add a user with a + in the username
            TestPlusUser = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = TestConnection.Name,
                Email = $"{Guid.NewGuid():N}+1{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = TestPassword
            });

            TrackIdentifier(CleanUpType.Users, TestPlusUser.UserId);

            // Add a user with a + in the username
            TestUserInDefaultDirectory = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = tenantSettings.DefaultDirectory,
                Email = $"{Guid.NewGuid():N}+1{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = TestPassword
            });

            TrackIdentifier(CleanUpType.Users, TestUserInDefaultDirectory.UserId);

            TestAuthenticationApiClient = new TestAuthenticationApiClient(TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL"));
        }
        public override async Task DisposeAsync()
        {
            foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
            {
                await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
            }

            ApiClient.Dispose();
        }
    }

    public class AuthenticationTests : IClassFixture<AuthenticationTestsFixture>
    {
        AuthenticationTestsFixture fixture;

        public AuthenticationTests(AuthenticationTestsFixture fixture)
        {
            this.fixture = fixture;
        }


        [Fact]
        public async Task Can_authenticate_against_Auth0()
        {
            // Act
            var authenticationResponse = await fixture.TestAuthenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                Realm = fixture.TestConnection.Name,
                Scope = "openid",
                Username = fixture.TestUser.Email,
                Password = fixture.TestPassword

            });

            // Assert
            authenticationResponse.Should().NotBeNull();
            authenticationResponse.TokenType.Should().NotBeNull();
            authenticationResponse.AccessToken.Should().NotBeNull();
            authenticationResponse.IdToken.Should().NotBeNull();
            authenticationResponse.RefreshToken.Should().BeNull(); // No refresh token if offline access was not requested
        }

        [Fact]
        public async Task Can_authenticate_to_default_directory()
        {
            // Act
            var authenticationResponse = await fixture.TestAuthenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                Scope = "openid",
                Username = fixture.TestUserInDefaultDirectory.Email,
                Password = fixture.TestPassword

            });

            // Assert
            authenticationResponse.Should().NotBeNull();
            authenticationResponse.TokenType.Should().NotBeNull();
            authenticationResponse.AccessToken.Should().NotBeNull();
            authenticationResponse.IdToken.Should().NotBeNull();
            authenticationResponse.RefreshToken.Should().BeNull(); // No refresh token if offline access was not requested
        }

        [Fact(Skip = "Need to look into offline_access")]
        public async Task Can_request_offline_access()
        {
            // Act
            var authenticationResponse = await fixture.TestAuthenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                Realm = fixture.TestConnection.Name,
                Scope = "openid offline_access",
                Username = fixture.TestUser.Email,
                Password = fixture.TestPassword
            });

            // Assert
            authenticationResponse.Should().NotBeNull();
            authenticationResponse.TokenType.Should().NotBeNull();
            authenticationResponse.AccessToken.Should().NotBeNull();
            authenticationResponse.IdToken.Should().NotBeNull();
            authenticationResponse.RefreshToken.Should().NotBeNull(); // Requested offline access, so we should get a refresh token
        }

        [Fact]
        public async Task Can_authenticate_user_with_plus_in_username()
        {
            // Act
            var authenticationResponse = await fixture.TestAuthenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                Realm = fixture.TestConnection.Name,
                Scope = "openid",
                Username = fixture.TestPlusUser.Email,
                Password = fixture.TestPassword
            });

            // Assert
            authenticationResponse.Should().NotBeNull();
            authenticationResponse.TokenType.Should().NotBeNull();
            authenticationResponse.AccessToken.Should().NotBeNull();
            authenticationResponse.IdToken.Should().NotBeNull();
        }
    }
}