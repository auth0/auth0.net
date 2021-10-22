using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to exchange a one time password, received through SMS, for an access token using the Passwordless flow.
    /// </summary>
    public class PasswordlessSmsTokenRequest : PasswordlessTokenRequestBase
    {
        /// <summary>
        /// Phonenumber used for the Passwordless flow
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// IP address of the end user this token is requested for for rate limit purposes.
        /// </summary>
        /// <remarks>
        /// See https://auth0.com/docs/connections/passwordless/best-practices#link-accounts for more details.
        /// </remarks>
        public string ForwardedForIp { get; set; }

    }
}