using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to authenticate with a connection.
    /// </summary>
    public class AuthenticationRequest
    {
        /// <summary>
        /// Gets or sets the client (app) identifier.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client (app) secret.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        public string Connection { get; set; }

        /// <summary>
        /// Gets or sets the grant type requested.
        /// </summary>
        public string GrantType { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the requested scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }
    }
}