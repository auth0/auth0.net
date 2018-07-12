using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Exceptions;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi
{
    public class IdentityTokenValidator
    {
        public async Task ValidateAsync(string identityToken, string domain, string audience)
        {
            JwtSecurityToken token;
            
            var handler = new JwtSecurityTokenHandler();

            try
            {
                // Try and read the token
                token = handler.ReadJwtToken(identityToken);
            }
            catch (Exception e)
            {
                throw new IdentityTokenValidationException($"Error validating identity token: {e.ToString()}");
            }

            // Determine the algorithm,
            string algorithm = token.Header.Alg;

            if (string.Equals(algorithm, "RS256", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    IConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{domain}.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
                    OpenIdConnectConfiguration openIdConfig = await configurationManager.GetConfigurationAsync(CancellationToken.None);
                
                    TokenValidationParameters validationParameters =
                        new TokenValidationParameters
                        {
                            ValidIssuer = domain,
                            ValidAudiences = new[] {audience},
                            IssuerSigningKeys = openIdConfig.SigningKeys
                        };

                    SecurityToken validatedToken;
                    handler.ValidateToken(identityToken, validationParameters, out validatedToken);
                }
                catch (Exception e)
                {
                    throw new IdentityTokenValidationException($"Error validating identity token: {e.ToString()}");
                }
            }
        }
    }
}