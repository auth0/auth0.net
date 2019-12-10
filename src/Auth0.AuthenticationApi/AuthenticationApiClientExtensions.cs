using Auth0.AuthenticationApi.Builders;

namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// Additional operations that can be performed against a <see cref="IAuthenticationApiClient"/>.
    /// </summary>
    public static class AuthenticationApiClientExtensions
    {
        /// <summary>
        /// Creates a <see cref="AuthorizationUrlBuilder" /> for building an authorization URL.
        /// </summary>
        /// <param name="client"><see cref="IAuthenticationApiClient"/> capable of providing the Base URL.</param>
        /// <returns>A new <see cref="AuthorizationUrlBuilder" /> configured for this baseUrl.</returns>
        public static AuthorizationUrlBuilder BuildAuthorizationUrl(this IAuthenticationApiClient client)
        {
            return new AuthorizationUrlBuilder(client.BaseUri);
        }

        /// <summary>
        /// Creates a <see cref="LogoutUrlBuilder" /> for building a logout URL.
        /// </summary>
        /// <param name="client"><see cref="IAuthenticationApiClient"/> capable of providing the Base URL.</param>
        /// <returns>A new <see cref="LogoutUrlBuilder" /> configured for this baseUrl.</returns>
        public static LogoutUrlBuilder BuildLogoutUrl(this IAuthenticationApiClient client)
        {
            return new LogoutUrlBuilder(client.BaseUri);
        }

        /// <summary>
        /// Creates a <see cref="SamlUrlBuilder" /> for building a SAML authentication URL.
        /// </summary>
        /// <param name="client"><see cref="IAuthenticationApiClient"/> capable of providing the Base URL.</param>
        /// <param name="clientId">ID of the client.</param>
        /// <returns>A new <see cref="SamlUrlBuilder" /> configured for this baseUrl and <paramref name="client"/>.</returns>
        public static SamlUrlBuilder BuildSamlUrl(this IAuthenticationApiClient client, string clientId)
        {
            return new SamlUrlBuilder(client.BaseUri, clientId);
        }

        /// <summary>
        /// Creates a <see cref="WsFedUrlBuilder" /> for building a WS-Federation authentication URL.
        /// </summary>
        /// <param name="client"><see cref="IAuthenticationApiClient"/> capable of providing the Base URL.</param>
        /// <returns>A new <see cref="WsFedUrlBuilder" /> configured for this baseUrl.</returns>
        public static WsFedUrlBuilder BuildWsFedUrl(this IAuthenticationApiClient client)
        {
            return new WsFedUrlBuilder(client.BaseUri);
        }
    }
}
