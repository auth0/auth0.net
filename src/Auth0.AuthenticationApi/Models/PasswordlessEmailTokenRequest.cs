using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to exchange a one time password, received through email, for an access token using the Passwordless flow.
    /// </summary>
    public class PasswordlessEmailTokenRequest : PasswordlessTokenRequestBase
    {
        /// <summary>
        /// Email used for the Passwordless flow
        /// </summary>
        public string Email { get; set; }
    }
}