using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    static class JsonWebKeys
    {
        public static async Task<JsonWebKeySet> GetForIssuer(string issuer)
        {
            var metadataAddress = new UriBuilder(issuer) { Path = "/.well-known/openid-configuration" }.Uri.OriginalString;
            var openIdConfiguration = await GetOpenIdConfiguration(metadataAddress);
            return openIdConfiguration.JsonWebKeySet;
        }

        private static Task<OpenIdConnectConfiguration> GetOpenIdConfiguration(string metadataAddress)
        {
            try
            {
                var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(metadataAddress, new OpenIdConnectConfigurationRetriever());
                return configurationManager.GetConfigurationAsync();
            }
            catch (Exception e)
            {
                throw new IdTokenValidationException($"Unable to retrieve public keys from \"${metadataAddress}\".", e);
            }
        }
    }
}