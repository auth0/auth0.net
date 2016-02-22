using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents an active authentication response with SSO support (a WS-Federation Login Form).
    /// </summary>
    public class UsernamePasswordLoginResponse
    {
        /// <summary>
        /// The HTML form.
        /// </summary>
        public string HtmlForm { get; set; }
    }
}