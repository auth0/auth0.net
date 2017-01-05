using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.Extensions.Configuration;

namespace Auth0.Tests.Shared
{
    public class TestBase
    {
        private IConfigurationRoot _config;

        public TestBase()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("client-secrets.json")
                .Build();
        }

        protected async Task<string> GenerateManagementApiToken()
        {
            var authenticationApiClient = new AuthenticationApiClient(new Uri(GetVariable("AUTH0_AUTHENTICATION_API_URL")));

            // Get the access token
            var token = await authenticationApiClient.GetToken(new ClientCredentialsTokenRequest
            {
                ClientId = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID"),
                ClientSecret = GetVariable("AUTH0_MANAGEMENT_API_CLIENT_SECRET"),
                Audience = GetVariable("AUTH0_MANAGEMENT_API_AUDIENCE")
            });

            return token.AccessToken;
        }

        //protected string GenerateToken(object scopes)
        //{
        //    string jti = Guid.NewGuid().ToString("N");

        //    return GenerateToken(scopes, jti);
        //}

        protected string GenerateToken(object scopes, string jti)
        {
            string apiKey = GetVariable("AUTH0_API_KEY");
            string apiSecret = GetVariable("AUTH0_API_SECRET");

            // Set token payload
            var payload = new Dictionary<string, object>()
            {
                {"aud", apiKey},
                {"jti", jti},
                {"scopes", scopes}
            };

            var keyAsBase64 = apiSecret.Replace('_', '/').Replace('-', '+');
            var secret = Convert.FromBase64String(keyAsBase64);
            return JWT.JsonWebToken.Encode(payload, secret, JWT.JwtHashAlgorithm.HS256);
        }

        protected string GetVariable(string variableName)
        {
            // Check to see whether we are running inside AopVeyor CI environment
            if (IsRunningUnderAppVeyorCi())
                return Environment.GetEnvironmentVariable(variableName);

            // By default return variable from config file
            return _config[variableName];
        }

        protected bool IsRunningUnderAppVeyorCi()
        {
            bool isAppVeyor = Environment.GetEnvironmentVariable("APPVEYOR") == "True";
            bool IsCi = Environment.GetEnvironmentVariable("CI") == "True";

            return isAppVeyor && IsCi;
        }
    }
}