using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models
{
    public interface IClientAuthentication
    {
        /// <summary>
        /// Client ID of the application.
        /// </summary>
        string ClientId { get; set; }

        /// <summary>
        /// Client Secret of the application.
        /// </summary>
        string ClientSecret { get; set; }

        /// <summary>
        /// Security Key to use with Client Assertion
        /// </summary>
        SecurityKey ClientAssertionSecurityKey { get; set; }

        /// <summary>
        /// Algorithm for the Security Key to use with Client Assertion
        /// </summary>
        string ClientAssertionSecurityKeyAlgorithm { get; set; }
    }
}