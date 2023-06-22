using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Tokens;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.IntegrationTests.Testing;
using Auth0.IntegrationTests.Shared.CleanUp;
using Xunit;
using System.Collections.Generic;
using System.Data.Common;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    public class IdTokenValidatorIntegrationTestsFixture : TestBaseFixture
    {
        public Connection Connection;
        public User User;
        public string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";


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
            Connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = "auth0",
                EnabledClients = new[] {
                    TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                    TestBaseUtils.GetVariable("AUTH0_HS256_CLIENT_ID"),
                    TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")
                }
            });

            TrackIdentifier(CleanUpType.Connections, Connection.Id);

            // And add a dummy user to test against
            User = await ApiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = Connection.Name,
                Email = $"{TestBaseUtils.MakeRandomName()}{TestingConstants.UserEmailDomain}",
                EmailVerified = true,
                Password = Password
            });

            TrackIdentifier(CleanUpType.Users, User.UserId);
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
    public class IdTokenValidatorIntegrationTests : IClassFixture<IdTokenValidatorIntegrationTestsFixture>
    {
        
        IdTokenValidatorIntegrationTestsFixture fixture;

        public IdTokenValidatorIntegrationTests(IdTokenValidatorIntegrationTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Passes_Token_Validation_RS256()
        {
            var authUrl = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
            var clientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID");
            var clientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET");

            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(authUrl))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Realm = fixture.Connection.Name,
                    Scope = "openid",
                    Username = fixture.User.Email,
                    Password = fixture.Password
                });

                var issuer = $"https://{authUrl}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, issuer, clientId, TimeSpan.FromMinutes(1));
                await new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, clientSecret);
            }
        }

        [Fact]
        public async Task Passes_Token_Validation_RS256_With_Document_Retreiver()
        {
            var authUrl = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
            var clientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID");
            var clientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET");

            // Arrange
            var connection = new TestHttpClientAuthenticationConnection();
            var documentRetreiver = new OpenIdConnectDocumentRetriever(connection);
            using (var authenticationApiClient = new TestAuthenticationApiClient(authUrl, connection))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Realm = fixture.Connection.Name,
                    Scope = "openid",
                    Username = fixture.User.Email,
                    Password = fixture.Password
                });

                var issuer = $"https://{authUrl}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, issuer, clientId, TimeSpan.FromMinutes(1));
                await new IdTokenValidator(documentRetreiver).Assert(requirements, authenticationResponse.IdToken, clientSecret);
            }
        }

        [Fact]
        public async Task Passes_Token_Validation_HS256()
        {
            var authUrl = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
            var clientId = TestBaseUtils.GetVariable("AUTH0_HS256_CLIENT_ID");
            var clientSecret = TestBaseUtils.GetVariable("AUTH0_HS256_CLIENT_SECRET");

            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(authUrl))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Realm = fixture.Connection.Name,
                    SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                    Scope = "openid",
                    Username = fixture.User.Email,
                    Password = fixture.Password
                });

                var issuer = $"https://{authUrl}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.HS256, issuer, clientId, TimeSpan.FromMinutes(1));
                await new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, clientSecret);
            }
        }

        [Fact]
        public async Task Passes_Token_Validation_HS256_With_Document_Retreiver()
        {
            var authUrl = TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL");
            var clientId = TestBaseUtils.GetVariable("AUTH0_HS256_CLIENT_ID");
            var clientSecret = TestBaseUtils.GetVariable("AUTH0_HS256_CLIENT_SECRET");

            // Arrange
            var connection = new TestHttpClientAuthenticationConnection();
            var documentRetreiver = new OpenIdConnectDocumentRetriever(connection);
            using (var authenticationApiClient = new TestAuthenticationApiClient(authUrl, connection))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Realm = fixture.Connection.Name,
                    SigningAlgorithm = JwtSignatureAlgorithm.HS256,
                    Scope = "openid",
                    Username = fixture.User.Email,
                    Password = fixture.Password
                });

                var issuer = $"https://{authUrl}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.HS256, issuer, clientId, TimeSpan.FromMinutes(1));
                await new IdTokenValidator(documentRetreiver).Assert(requirements, authenticationResponse.IdToken, clientSecret);
            }
        }

        [Fact]
        public async Task Passes_Token_Validation_With_CNAME()
        {
            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                    ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                    Realm = fixture.Connection.Name,
                    Scope = "openid",
                    Username = fixture.User.Email,
                    Password = fixture.Password
                });

                var issuer = $"https://{TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL")}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, issuer, TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TimeSpan.FromMinutes(1));
                await new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"));
            }
        }

        [Fact]
        public async Task Fails_Token_Validation_With_Incorrect_Domain()
        {
            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                    ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                    Realm = fixture.Connection.Name,
                    Scope = "openid",
                    Username = fixture.User.Email,
                    Password = fixture.Password

                });

                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, "https://auth0.auth0.com/", TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"), TimeSpan.FromMinutes(1));

                // Assert
                authenticationResponse.IdToken.Should().NotBeNull();
                await Assert.ThrowsAsync<IdTokenValidationKeyMissingException>(() => new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET")));
            }
        }

        [Fact]
        public async Task Fails_Token_Validation_With_Incorrect_Audience()
        {
            // Arrange
            using (var authenticationApiClient = new TestAuthenticationApiClient(TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                // Act
                var authenticationResponse = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                    ClientSecret = TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET"),
                    Realm = fixture.Connection.Name,
                    Scope = "openid",
                    Username = fixture.User.Email,
                    Password = fixture.Password

                });

                var issuer = $"https://{TestBaseUtils.GetVariable("AUTH0_AUTHENTICATION_API_URL")}/";
                var requirements = new IdTokenRequirements(JwtSignatureAlgorithm.RS256, issuer, "invalid_audience", TimeSpan.FromMinutes(1));

                // Assert
                authenticationResponse.IdToken.Should().NotBeNull();
                await Assert.ThrowsAsync<IdTokenValidationException>(() => new IdTokenValidator().Assert(requirements, authenticationResponse.IdToken, TestBaseUtils.GetVariable("AUTH0_CLIENT_SECRET")));
            }
        }
    }
}