using Auth0.AuthenticationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth0.AuthenticationApi.Builders
{
    /// <summary>
    /// Builder class used to fluently construct an authorization URL.
    /// </summary>
    /// <remarks>
    /// See https://auth0.com/docs/api/authentication#login for more details.
    /// </remarks>
    public class AuthorizationUrlBuilder : UrlBuilderBase<AuthorizationUrlBuilder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL of the Authentication API represented as a <see cref="String"/>.</param>
        public AuthorizationUrlBuilder(string baseUrl)
            : base(baseUrl, "authorize")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationUrlBuilder"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL of the Authentication API represented as a <see cref="Uri"/>.</param>
        public AuthorizationUrlBuilder(Uri baseUrl)
            : base(baseUrl, "authorize")
        {
        }

        /// <summary>
        /// Adds the `client_id` query string parameter specifying the Client ID of the application.
        /// </summary>
        /// <param name="clientId">Client ID of the application.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithClient(string clientId)
        {
            return WithValue("client_id", clientId);
        }

        /// <summary>
        /// Adds the `connection` query string parameter specifying the connection name.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithConnection(string connectionName)
        {
            return WithValue("connection", connectionName);
        }

        /// <summary>
        /// Adds the `redirect_uri` query string parameter specifying the redirect URI.
        /// </summary>
        /// <param name="uri">URI to redirect to.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithRedirectUrl(string uri)
        {
            return WithValue("redirect_uri", uri);
        }
        /// <summary>
        /// Adds the `redirect_uri` query string parameter specifying the redirect URI.
        /// </summary>
        /// <param name="uri"><see cref="Uri"/> to redirect to.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithRedirectUrl(Uri uri)
        {
            return WithRedirectUrl(uri.OriginalString);
        }

        /// <summary>
        /// Adds the `response_type` query string parameter specifying the types of responses 
        /// that the client expects.
        /// </summary>
        /// <param name="responseType"><see cref="AuthorizationResponseType"/> the client expects.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithResponseType(params AuthorizationResponseType[] responseType)
        {
            return WithValue("response_type",
                string.Join(" ", responseType
                    .Select(r =>
                    {
                        var value = r.ToStringValue();
                        if (value == null)
                        {
                            throw new ArgumentException("Unknown AuthorizationResponseType.", nameof(responseType));
                        }

                        return value;
                    })));
        }

        /// <summary>
        /// Adds the `scope` query string parameter indicating the scopes the client wants to request.
        /// </summary>
        /// <param name="scope">Scopes to request. Multiple scopes must be separated by a space character.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithScope(string scope)
        {
            return WithValue("scope", scope);
        }

        /// <summary>
        /// Adds the `scope` query string parameter indicating the scopes the client wants to request.
        /// </summary>
        /// <param name="scopes">Scopes the client wants to request.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithScopes(params string[] scopes)
        {
            return WithScope(String.Join(" ", scopes));
        }

        /// <summary>
        /// Adds the `state` query string parameter specifying a value to be returned on completion in 
        /// order to prevent CSRF attacks.
        /// </summary>
        /// <param name="state">State value to be passed back on successful authorization.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithState(string state)
        {
            return WithValue("state", state);
        }

        /// <summary>
        /// Adds the `audience` query string parameter to request API access.
        /// </summary>
        /// <param name="audience">Audience to request API access for.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithAudience(string audience)
        {
            return WithValue("audience", audience);
        }

        /// <summary>
        /// Adds the `nonce` query string parameter specifying a cryptographically random nonce.
        /// </summary>
        /// <param name="nonce">The nonce.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        /// <remarks>See https://auth0.com/docs/api-auth/tutorials/nonce for more details</remarks>
        public AuthorizationUrlBuilder WithNonce(string nonce)
        {
            return WithValue("nonce", nonce);
        }

        /// <summary>
        /// Adds the `response_mode` query string parameter.
        /// </summary>
        /// <param name="responseMode">Response mode to use.</param>
        /// <returns>The <see cref="AuthorizationUrlBuilder"/>.</returns>
        public AuthorizationUrlBuilder WithResponseMode(AuthorizationResponseMode responseMode)
        {
            if (responseMode != AuthorizationResponseMode.FormPost)
                throw new ArgumentOutOfRangeException("Unknown AuthorizationResponseMode.", nameof(responseMode));

            return WithValue("response_mode", "form_post");
        }

        /// <summary>
        /// Adds the `connection_scope` query string parameter.
        /// </summary>
        /// <param name="connectionScope">Connection scope to be passed to the corresponding connection. Multiple scopes must be separated by a space character.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithConnectionScope(string connectionScope)
        {
            return WithValue("connection_scope", connectionScope);
        }

        /// <summary>
        /// Adds the `connection_scope` query string parameter.
        /// </summary>
        /// <param name="connectionScope">Connection scopes to be passed to the corresponding connection.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithConnectionScopes(params string[] connectionScope)
        {
            return WithConnectionScope(String.Join(" ", connectionScope));
        }

        /// <summary>
        /// Adds the `organization` query string parameter.
        /// </summary>
        /// <param name="organization">The ID of the organization to log the user in to</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithOrganization(string organization)
        {
            return WithValue("organization", organization);
        }

        /// <summary>
        /// Adds the `invitation` query string parameter.
        /// </summary>
        /// <param name="invitation">The Id of an invitation to accept. This is available from the URL that is given when participating in a user invitation flow.</param>
        /// <returns>Current <see cref="AuthorizationUrlBuilder"/> to allow fluent configuration.</returns>
        public AuthorizationUrlBuilder WithInvitation(string invitation)
        {
            return WithValue("invitation", invitation);
        }
    }
}
