using System;

namespace Auth0.AuthenticationApi.Builders
{
    /// <summary>
    /// Builder class used to fluently construct a logout URL.
    /// </summary>
    /// <remarks>
    /// See https://auth0.com/docs/api/authentication#logout
    /// </remarks>
    public class LogoutUrlBuilder : UrlBuilderBase<LogoutUrlBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogoutUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL of the Authentication API represented as a <see cref="String"/>.</param>
        public LogoutUrlBuilder(string baseUrl)
            : base(baseUrl, "v2/logout")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogoutUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL of the Authentication API represented as a <see cref="Uri"/>.</param>
        public LogoutUrlBuilder(Uri baseUrl)
            : base(baseUrl, "v2/logout")
        {
        }

        /// <summary>
        /// Adds the `redirect_uri` query string parameter specifying the redirect URI.
        /// </summary>
        /// <param name="uri">URI to redirect to.</param>
        /// <returns>Current <see cref="LogoutUrlBuilder"/> to allow fluent configuration.</returns>
        public LogoutUrlBuilder WithReturnUrl(string uri)
        {
            return WithValue("returnTo", uri);
        }

        /// <summary>
        /// Adds the `redirect_uri` query string parameter specifying the redirect URI.
        /// </summary>
        /// <param name="uri"><see cref="Uri"/> to redirect to.</param>
        /// <returns>Current <see cref="LogoutUrlBuilder"/> to allow fluent configuration.</returns>
        public LogoutUrlBuilder WithReturnUrl(Uri uri)
        {
            return WithReturnUrl(uri.OriginalString);
        }

        /// <summary>
        /// Adds the `client_id` query string parameter specifying the Client ID of the application.
        /// </summary>
        /// <param name="clientId">Client ID of the application.</param>
        /// <returns>Current <see cref="LogoutUrlBuilder"/> to allow fluent configuration.</returns>
        public LogoutUrlBuilder WithClientId(string clientId)
        {
            return WithValue("client_id", clientId);
        }

        /// <summary>
        /// Adds the `federated` flag query string parameter (no value).
        /// </summary>
        /// <returns>Current <see cref="LogoutUrlBuilder"/> to allow fluent configuration.</returns>
        public LogoutUrlBuilder Federated()
        {
            return WithValue("federated", null);
        }
    }
}