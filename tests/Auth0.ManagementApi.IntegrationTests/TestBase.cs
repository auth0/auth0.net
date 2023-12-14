using Auth0.AuthenticationApi.Models;
using Microsoft.IdentityModel.Logging;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Xunit;

// We do not want to hit the management API rate limit
[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace Auth0.Tests.Shared
{
    public class TestBase
    {
        static TestBase()
        {
            // Microsoft hide lots of exception detail by default. Fine in production
            // but for tests we want to see it.
            IdentityModelEventSource.ShowPII = true;
        }

        public static readonly IConfigurationRoot Config = new ConfigurationBuilder()
                .AddJsonFile("client-secrets.json", true)
                .AddEnvironmentVariables()
                .Build();

        private readonly Regex _alphaNumeric = new Regex("[^a-zA-Z0-9]");

        protected string MakeRandomName()
        {
            return _alphaNumeric.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "");
        }

        protected async Task<string> GenerateBruckeManagementApiToken()
        {
            using (var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("BRUCKE_AUTHENTICATION_API_URL")))
            {
                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = GetVariable("BRUCKE_MANAGEMENT_API_CLIENT_ID"),
                    ClientSecret = GetVariable("BRUCKE_MANAGEMENT_API_CLIENT_SECRET"),
                    Audience = GetVariable("BRUCKE_MANAGEMENT_API_AUDIENCE")
                });

                return token.AccessToken;
            }
        }

        protected async Task<string> GenerateManagementApiToken()
        {
            using (var authenticationApiClient = new TestAuthenticationApiClient(GetVariable("AUTH0_AUTHENTICATION_API_URL")))
            {
                // Get the access token
                var token = await authenticationApiClient.GetTokenAsync(new ClientCredentialsTokenRequest
                {
                    ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
                    ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
                    Audience = GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE")
                });

                return token.AccessToken;
            }
        }

        protected static string GetVariable(string variableName, bool throwIfMissing = true)
        {
            var value = Config[variableName];
            if (String.IsNullOrEmpty(value) && throwIfMissing)
                throw new ArgumentOutOfRangeException($"Configuration value '{variableName}' has not been set.");
            return value;
        }
    }
}