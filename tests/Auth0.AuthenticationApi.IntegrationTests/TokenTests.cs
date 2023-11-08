using Auth0.AuthenticationApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.AuthenticationApi.IntegrationTests
{
    public class TokenTests : TestBase
    {
        [Fact]
        public async Task Can_get_token_using_client_credentials()
        {
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
                    Audience = GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE")
                });

                // Ensure that we received an access token back
                token.Should().NotBeNull();
            }
        }
        
        [Fact]
        public async Task Can_get_token_using_client_credentials_for_organization()
        {
            var existingOrgId = "org_V6ojENVd1ERs5YY1";
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = GetVariable("AUTH0_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTH0_CLIENT_SECRET"),
                    Audience = "dotnet-testing",
                    Organization = existingOrgId
                });

                // Ensure that we received an access token back
                token.Should().NotBeNull();
                  
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token.AccessToken);
                var orgIdClaim = jwtSecurityToken.Claims.First(claim => claim.Type == "org_id").Value;
                
                orgIdClaim.Should().NotBeNull();
                orgIdClaim.Should().Be(existingOrgId);
            }
        }

        [Fact(Skip = "Run Manual")]
        public async Task Can_get_token_using_client_credentials_and_ca()
        {
            // Be sure to use a client that supports CA.
            var domain = "";
            var clientId = "";

            using (var authenticationApiClient = new AuthenticationApiClient(domain))
            {

                var privateKeyPem = @"";

                byte[] privateKeyRaw = Convert.FromBase64String(privateKeyPem);
                using var provider = new RSACryptoServiceProvider(2048);
                provider.ImportRSAPrivateKey(new ReadOnlySpan<byte>(privateKeyRaw), out _);

                var key = new RsaSecurityKey(provider);

                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = clientId,
                    Audience = $"https://{domain}/api/v2/",
                    ClientAssertionSecurityKey = key,
                    ClientAssertionSecurityKeyAlgorithm = SecurityAlgorithms.RsaSha256
                });

                // Ensure that we received an access token back
                token.Should().NotBeNull();
            }
        }

        [Fact(Skip = "Run Manual")]
        public async Task Can_get_token_using_resource_owner_and_ca()
        {
            // Be sure to use a client that supports CA.
            var domain = "";
            var clientId = "";

            using (var authenticationApiClient = new AuthenticationApiClient(domain))
            {
                var privateKeyPem = @"";

                byte[] privateKeyRaw = Convert.FromBase64String(privateKeyPem);
                using var provider = new RSACryptoServiceProvider(2048);
                provider.ImportRSAPrivateKey(new ReadOnlySpan<byte>(privateKeyRaw), out _);

                var key = new RsaSecurityKey(provider);

                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
                {
                    ClientId = clientId,
                    Audience = $"https://{domain}/api/v2/",
                    ClientAssertionSecurityKey = key,
                    ClientAssertionSecurityKeyAlgorithm = SecurityAlgorithms.RsaSha256,
                    Username = "",
                    Password = "",
                    Scope = "openid"
                });

                // Ensure that we received an access token back
                token.Should().NotBeNull();
            }
        }

        [Fact(Skip = "Run Manual")]
        public async Task Can_get_token_using_passwordless_email_and_ca()
        {
            // Be sure to use a client that supports CA.
            var domain = "";
            var clientId = "";

            using (var authenticationApiClient = new AuthenticationApiClient(domain))
            {

                var privateKeyPem = @"...";

                byte[] privateKeyRaw = Convert.FromBase64String(privateKeyPem);
                using var provider = new RSACryptoServiceProvider(2048);
                provider.ImportRSAPrivateKey(new ReadOnlySpan<byte>(privateKeyRaw), out _);

                var key = new RsaSecurityKey(provider);

                await authenticationApiClient.StartPasswordlessEmailFlowAsync(new PasswordlessEmailRequest
                {
                    ClientAssertionSecurityKey = key,
                    ClientAssertionSecurityKeyAlgorithm = SecurityAlgorithms.RsaSha256,
                    ClientId = clientId,
                    Type = PasswordlessEmailRequestType.Code,
                    Email = ""
                });

                var code = "";

                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new PasswordlessEmailTokenRequest
                {
                    ClientId = clientId,
                    Audience = $"https://{domain}/api/v2/",
                    ClientAssertionSecurityKey = key,
                    ClientAssertionSecurityKeyAlgorithm = SecurityAlgorithms.RsaSha256,
                    Code = code,
                    Email = ""
                });

                // Ensure that we received an access token back
                token.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task Can_revoke_refresh_token_when_token_not_null()
        {
            using (var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                await authenticationApiClient.RevokeRefreshTokenAsync(new RevokeRefreshTokenRequest
                {
                    ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
                    RefreshToken = "SomeRefreshToken"
                });
            }
        }
    }
}
