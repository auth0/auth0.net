using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using FluentAssertions;
using Microsoft.Owin.Security.DataHandler.Encoder;
using NUnit.Framework;
using Auth0.ManagementApi.Client.Models;

namespace Auth0.ManagementApi.Client.IntegrationTests
{
    [TestFixture]
    public class BlacklistedTokensTests : TestBase
    {
        [Test]
        [Ignore("Ignore for now until I can figure out reason for intermittent failure")]
        public async Task Test_blacklist_sequence()
        {
            string apiKey = GetVariable("AUTH0_API_KEY");

            var apiClient = new ManagementApiClient(GetVariable("AUTH0_TOKEN_BLACKLISTED_TOKENS"), new Uri(GetVariable("AUTH0_API_URL")));

            // Get all the blacklisted tokens
            var tokensBefore = await apiClient.BlacklistedTokens.GetAll(apiKey);

            // Generate a token which allows us to list all clients
            string jti = Guid.NewGuid().ToString("N");
            string token = GenerateToken(jti);

            // Confirm that the token is working
            var confirmationApiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_API_URL")));
            var clients = await confirmationApiClient.Clients.GetAll();
            clients.Should().NotBeNull();

            // Now blacklist that new token
            var blacklistRequest = new BlacklistedTokenCreateRequest
            {
                Aud = apiKey,
                Jti = jti
            };
            await apiClient.BlacklistedTokens.Create(blacklistRequest);

            // Get all the blacklisted tokens and check that we have one more
            var tokensAfter = await apiClient.BlacklistedTokens.GetAll(apiKey);
            tokensAfter.Count.Should().Be(tokensBefore.Count + 1);

            // Try and get all the clients again with that token
            Func<Task> getFunc = async () => await confirmationApiClient.Clients.GetAll();
            getFunc.ShouldThrow<ApiException>().And.ApiError.StatusCode.Should().Be(401);
        }

        private string GenerateToken(string jti)
        {
            // Generate a token to 
            string apiKey = GetVariable("AUTH0_API_KEY");
            string apiSecret = GetVariable("AUTH0_API_SECRET");

            // Set scopes
            var scopes = new
            {
                clients = new
                {
                    actions = new string[] { "read" }
                }
            };

            // Set token payload
            var payload = new Dictionary<string, object>()
            {
                {"aud", apiKey},
                {"jti", jti},
                {"scopes", scopes}
            };

            return JWT.JsonWebToken.Encode(payload, TextEncodings.Base64Url.Decode(apiSecret), JWT.JwtHashAlgorithm.HS256);
        }
    }
}