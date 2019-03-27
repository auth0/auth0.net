using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.Extensions.Configuration;
using Xunit;

// We do not want to hit the management API rate limit
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Auth0.Tests.Shared
{
    public class TestBase
    {
        private readonly IConfigurationRoot _config;

        public TestBase()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("client-secrets.json", true)
                .AddEnvironmentVariables()
                .Build();
        }

        protected async Task<string> GenerateManagementApiToken()
        {
            var authenticationApiClient = new AuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL"));

            // Get the access token
            var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
            {
                ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
                Audience = GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE")
            });

            return token.AccessToken;
        }

        protected string GetVariable(string variableName)
        {
            var value = _config[variableName];
            if (String.IsNullOrEmpty(value))
                throw new ArgumentOutOfRangeException($"Configuration value '{variableName}' has not been set.");
            return value;
        }
    }
}