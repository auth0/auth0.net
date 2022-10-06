using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class JsonWebKeys
    {
        private readonly IDocumentRetriever openIdConnectDocumentRetriever;

        public JsonWebKeys(IDocumentRetriever openIdConnectDocumentRetriever = null)
        {
            this.openIdConnectDocumentRetriever = openIdConnectDocumentRetriever;
        }

        public async Task<JsonWebKeySet> GetForIssuer(string issuer)
        {
            var metadataAddress = new UriBuilder(issuer) { Path = "/.well-known/openid-configuration" }.Uri.OriginalString;
            var openIdConfiguration = await GetOpenIdConfiguration(metadataAddress).ConfigureAwait(false);
            return openIdConfiguration.JsonWebKeySet;
        }

        private Task<OpenIdConnectConfiguration> GetOpenIdConfiguration(string metadataAddress)
        {
            try
            {
                var configurationManager = openIdConnectDocumentRetriever != null ? new ConfigurationManager<OpenIdConnectConfiguration>(metadataAddress, new OpenIdConnectConfigurationRetriever(), openIdConnectDocumentRetriever) : new ConfigurationManager<OpenIdConnectConfiguration>(metadataAddress, new OpenIdConnectConfigurationRetriever());
                return configurationManager.GetConfigurationAsync();
            }
            catch (Exception e)
            {
                throw new IdTokenValidationException($"Unable to retrieve public keys from \"${metadataAddress}\".", e);
            }
        }
    }
}