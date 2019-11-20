using Auth0.AuthenticationApi.Models;
using System.Linq;

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
        /// Adds an access_token query string parameter.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public AuthorizationUrlBuilder WithAccessToken(string accessToken)
        {
            AddQueryString("access_token", accessToken);

            return this;
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
        /// Adds a new response_type query string parameter indicating 
        /// the type of response that the client expects.
        /// </summary>
        /// <param name="responseType">Type of the response.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithResponseType(params AuthorizationResponseType[] responseType)
        {
            AddQueryString("response_type", string.Join(" ",responseType.Select(AuthorizationResponseTypeHelper.ConvertToString)));

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

        /// <summary>
        /// Adds a new audience query string parameter.
        /// </summary>
        /// <param name="audience">The audience.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithAudience(string audience)
        {
            AddQueryString("audience", audience);

            return this;
        }

        /// <summary>
        /// Adds a new nonce query string parameter.
        /// </summary>
        /// <param name="nonce">The nonce.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithNonce(string nonce)
        {
            AddQueryString("nonce", nonce);

            return this;
        }

        /// <summary>
        /// Adds a new response_mode query string parameter.
        /// </summary>
        /// <param name="responseMode">The response mode.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithResponseMode(AuthorizationResponseMode responseMode)
        {
            AddQueryString("response_mode", AuthorizationResponseModeHelper.ConvertToString(responseMode));

            return this;
        }

        /// <summary>
        /// Adds a new connection_scope query string parameter.
        /// </summary>
        /// <param name="connectionScope">The connection scope to be passed to the corresponding connection. Multiple scopes must be separated by a space character.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithConnectionScope(string connectionScope)
        {
            AddQueryString("connection_scope", connectionScope);

            return this;
        }
    }
}