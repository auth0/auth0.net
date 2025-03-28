using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models.Mfa
{
    public class MfaOobTokenRequest : IClientAuthentication
    {
        /// <inheritdoc />
        public string ClientId { get; set; }

        /// <inheritdoc />
        public string ClientSecret { get; set; }

        /// <inheritdoc />
        public SecurityKey ClientAssertionSecurityKey { get; set; }

        /// <inheritdoc />
        public string ClientAssertionSecurityKeyAlgorithm { get; set; }

        /// <summary>
        /// The mfa_token you received from mfa_required error OR
        /// access token with enroll scope and audience: https://{yourDomain}/mfa/
        /// </summary>
        public string MfaToken { get; set; }

        /// <summary>
        /// The oob code received from the challenge request.
        /// </summary>
        public string OobCode { get; set; }

        /// <summary>
        /// A code used to bind the side channel with the main channel you are using to authenticate.
        /// </summary>
        public string BindingCode { get; set; }
    }
}