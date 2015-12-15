using Auth0.AuthenticationApi.Models;

namespace Auth0.AuthenticationApi.Builders
{
    /// <summary>
    /// Used to build am authorization URL.
    /// </summary>
    public class AuthorizationUrlBuilder : UrlBuilderBase<AuthorizationUrlBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL of the Authentication API.</param>
        public AuthorizationUrlBuilder(string baseUrl) 
            : base(baseUrl, "authorize")
        {
        }

        /// <summary>
        /// Adds a new client_id query string parameter.
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithClient(string clientId)
        {
            AddQueryString("client_id", clientId);

            return this;
        }

        /// <summary>
        /// Add a new connection query string parameter.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithConnection(string connectionName)
        {
            AddQueryString("connection", connectionName);

            return this;
        }

        /// <summary>
        /// Adds a new device query string parameter.
        /// </summary>
        /// <param name="device">The device.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithDevice(string device)
        {
            AddQueryString("device", device);

            return this;
        }

        /// <summary>
        /// Adds a new redirect_uri query string parameter
        /// </summary>
        /// <param name="url">The URL of the redirect URI</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithRedirectUrl(string url)
        {
            AddQueryString("redirect_uri", url);

            return this;
        }

        /// <summary>
        /// Adds a new response_type query string parameter indicating whether a code or a token must be returned.
        /// </summary>
        /// <param name="responseType">Type of the response.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithResponseType(AuthorizationResponseType responseType)
        {
            AddQueryString("response_type", responseType.ToString().ToLower());

            return this;
        }

        /// <summary>
        /// Adds a new scope query string parameter.
        /// </summary>
        /// <param name="scope">The scope. Multiple scopes must be separated by a space character.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithScope(string scope)
        {
            AddQueryString("scope", scope);

            return this;
        }

        /// <summary>
        /// Adds a new state query string parameter.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithState(string state)
        {
            AddQueryString("state", state);

            return this;
        }
    }
}