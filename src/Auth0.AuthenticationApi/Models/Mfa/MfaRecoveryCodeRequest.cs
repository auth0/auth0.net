using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models.Mfa
{
    public class MfaRecoveryCodeRequest : IClientAuthentication
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
        /// The mfa_token you received from mfa_required error
        /// </summary>
        public string MfaToken { get; set; }

        /// <summary>
        /// Recovery code provided by the end-user.
        /// </summary>
        public string RecoveryCode { get; set; }
    }
}