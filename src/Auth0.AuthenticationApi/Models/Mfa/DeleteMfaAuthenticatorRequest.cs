
namespace Auth0.AuthenticationApi.Models.Mfa
{
    public class DeleteMfaAuthenticatorRequest
    {
        /// <summary>
        /// Access token with scope: remove:authenticators and audience: https://{yourDomain}/mfa/
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The ID of the authenticator to delete.
        /// </summary>
        public string AuthenticatorId { get; set; }
    }
}