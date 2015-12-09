using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace Auth0.Tests.Shared
{
    public class TestBase
    {
        protected string GenerateToken(object scopes)
        {
            string jti = Guid.NewGuid().ToString("N");

            return GenerateToken(scopes, jti);
        }

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

            return JWT.JsonWebToken.Encode(payload, TextEncodings.Base64Url.Decode(apiSecret), JWT.JwtHashAlgorithm.HS256);
        }

        protected string GetVariable(string variableName)
        {
            // Check to see whether we are running inside AopVeyor CI environment
            if (IsRunningUnderAppVeyorCi())
                return Environment.GetEnvironmentVariable(variableName);

            // By default return variable from config file
            return ConfigurationManager.AppSettings[variableName];
        }

        protected bool IsRunningUnderAppVeyorCi()
        {
            bool isAppVeyor = Environment.GetEnvironmentVariable("APPVEYOR") == "True";
            bool IsCi = Environment.GetEnvironmentVariable("CI") == "True";

            return isAppVeyor && IsCi;
        }
    }
}