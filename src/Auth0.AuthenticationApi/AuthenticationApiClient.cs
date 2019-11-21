using Auth0.AuthenticationApi.Builders;
using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Tokens;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// Client for the Auth0 Authentication API.
    /// </summary>
    /// <remarks>
    /// Full documentation on the Auth0 Authentication API is available at https://auth0.com/docs/auth-api
    /// </remarks>
    public class AuthenticationApiClient : IAuthenticationApiClient, IDisposable
    {
        readonly Uri baseUri;
        readonly Uri tokenUri;
        readonly IAuthenticationConnection connection;
        bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">Your Auth0 domain URI, e.g. https://tenant.auth0.com</param>
        /// <param name="handler">Optional <see cref="IAuthenticationConnection"/> used to influence connection behavior.
        /// Defaults to a freshly created <see cref="HttpClientAuthenticationConnection"/> that uses a single <see cref="HttpClient"/>.</param>
        /// <remarks>To use a custom <see cref="HttpClient"/> or <see cref="HttpMessageHandler"/> create a 
        /// <see cref="HttpClientAuthenticationConnection"/> passing that into the constructor. e.g.
        /// <code>var client = new AuthenticationApiClient(new HttpClientAuthenticationConnection(myHttpClient));</code> or
        /// <code>var client = new AuthenticationApiClient(new HttpClientAuthenticationConnection(myHttpMessageHandler));</code> or
        /// </remarks>
        public AuthenticationApiClient(Uri baseUri, IAuthenticationConnection connection = null)
        {
            this.baseUri = baseUri;
            this.connection = connection ?? new HttpClientAuthenticationConnection();
            tokenUri = BuildUri("oauth/token");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="domain">Your Auth0 domain name, e.g. tenant.auth0.com.</param>
        /// <param name="handler">Optional <see cref="IAuthenticationConnection"/> used to influence connection behavior.
        /// Defaults to a freshly created <see cref="HttpClientAuthenticationConnection"/> that uses a single <see cref="HttpClient"/>.</param>
        /// <remarks>To use a custom <see cref="HttpClient"/> or <see cref="HttpMessageHandler"/> create a 
        /// <see cref="HttpClientAuthenticationConnection"/> passing that into the constructor. e.g.
        /// <code>var client = new AuthenticationApiClient(new HttpClientAuthenticationConnection(myHttpClient));</code> or
        /// <code>var client = new AuthenticationApiClient(new HttpClientAuthenticationConnection(myHttpMessageHandler));</code> or
        /// </remarks>
        public AuthenticationApiClient(string domain, IAuthenticationConnection connection = null)
            : this(new Uri($"https://{domain}"), connection)
        {
        }

        /// <summary>
        /// Creates a <see cref="AuthorizationUrlBuilder" /> for building an authorization URL.
        /// </summary>
        /// <returns>A new <see cref="AuthorizationUrlBuilder" /> configured for this baseUrl.</returns>
        public AuthorizationUrlBuilder BuildAuthorizationUrl()
        {
            return new AuthorizationUrlBuilder(baseUri.ToString());
        }

        /// <summary>
        /// Creates a <see cref="LogoutUrlBuilder" /> for building a logout URL.
        /// </summary>
        /// <returns>A new <see cref="LogoutUrlBuilder" /> configured for this baseUrl.</returns>
        public LogoutUrlBuilder BuildLogoutUrl()
        {
            return new LogoutUrlBuilder(baseUri.ToString());
        }

        /// <summary>
        /// Creates a <see cref="SamlUrlBuilder" /> for building a SAML authentication URL.
        /// </summary>
        /// <param name="client">Name of the client.</param>
        /// <returns>A new <see cref="SamlUrlBuilder" /> configured for this baseUrl and <paramref name="client"/>.</returns>
        public SamlUrlBuilder BuildSamlUrl(string client)
        {
            return new SamlUrlBuilder(baseUri.ToString(), client);
        }

        /// <summary>
        /// Creates a <see cref="WsFedUrlBuilder" /> for building a WS-Federation authentication URL.
        /// </summary>
        /// <returns>A new <see cref="WsFedUrlBuilder" /> configured for this baseUrl.</returns>
        public WsFedUrlBuilder BuildWsFedUrl()
        {
            return new WsFedUrlBuilder(baseUri.ToString());
        }

        /// <summary>
        /// Requests a password change email for a given email address and connection.
        /// </summary>
        /// <param name="request"><see cref="ChangePasswordRequest" /> specifying the user, connection and optional client details.</param>
        /// <returns>A string that may contain either the JSON error response or the plain text success message from Auth0.</returns>
        public Task<string> ChangePasswordAsync(ChangePasswordRequest request)
        {
            return connection.SendAsync<string>(
                HttpMethod.Post,
                BuildUri("dbconnections/change_password"),
                request);
        }

        /// <summary>
        /// Obtains a one-time link that can be used to log in as a specific user.
        /// </summary>
        /// <param name="request">The <see cref="ImpersonationRequest"/> containing the details of the user to impersonate.</param>
        /// <returns>A <see cref="Uri"/> which can be used to sign in as the specified user.</returns>
        /// <remarks>This feature has been deprecated and will be removed from Auth0 and this library in a future release.</remarks>
        public async Task<Uri> GetImpersonationUrlAsync(ImpersonationRequest request)
        {
            var body = new
            {
                protocol = request.Protocol,
                impersonator_id = request.ImpersonatorId,
                client_id = request.ClientId,
                response_type = request.ResponseType,
                state = request.State
            };

            var response = await connection.SendAsync<string>(
                HttpMethod.Post,
                BuildUri($"users/{request.ImpersonateId}/impersonate"),
                body,
                BuildHeaders(request.Token)
            ).ConfigureAwait(false);

            return new Uri(response);
        }

        /// <summary>
        /// Returns the SAML 2.0 metadata for a client.
        /// </summary>
        /// <param name="clientId">The client (application) ID for which metadata must be returned.</param>
        /// <returns>SAML 2.0 metadata XML as a string.</returns>
        public Task<string> GetSamlMetadataAsync(string clientId)
        {
            return connection.GetAsync<string>(BuildUri($"wsfed/{clientId}"));
        }

        /// <summary>
        /// Exchange an Authorization Code for an Access Token.
        /// </summary>
        /// <param name="request"><see cref="AuthorizationCodeTokenRequest"/> containing Authorization Code details.</param>
        /// <returns><see cref="AccessTokenResponse"/> containing requested tokens.</returns>
        public async Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodeTokenRequest request)
        {
            var body = new Dictionary<string, object> {
                { "grant_type", "authorization_code" },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret },
                { "code", request.Code },
                { "redirect_uri", request.RedirectUri } };

            var response = await connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Exchange an Authorization Code using PKCE for an Access Token.
        /// </summary>
        /// <param name="request"><see cref="AuthorizationCodePkceTokenRequest"/> containing Authorization Code and PKCE details.</param>
        /// <returns><see cref="AccessTokenResponse"/> containing the desired token information.</returns>
        public async Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodePkceTokenRequest request)
        {
            var body = new Dictionary<string, string> {
                { "grant_type", "authorization_code" },
                { "client_id", request.ClientId },
                { "code", request.Code },
                { "code_verifier", request.CodeVerifier },
                { "redirect_uri", request.RedirectUri } };

            var response = await connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Request an Access Token using the Client Credentials Grant flow.
        /// </summary>
        /// <param name="request">The <see cref="ClientCredentialsTokenRequest"/> containing the information of the request.</param>
        /// <returns><see cref="AccessTokenResponse"/> containing the desired token information.</returns>
        public Task<AccessTokenResponse> GetTokenAsync(ClientCredentialsTokenRequest request)
        {
            var body = new Dictionary<string, string> {
                { "grant_type", "client_credentials" },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret },
                { "audience", request.Audience } };

            return connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body);
        }

        /// <summary>
        /// Refresh all tokens using the Refresh Token obtained during authorization.
        /// </summary>
        /// <param name="request"><see cref="RefreshTokenRequest"/> containing Refresh Token and associated parameters.</param>
        /// <returns><see cref="AccessTokenResponse"/> containing the desired token information.</returns>
        public async Task<AccessTokenResponse> GetTokenAsync(RefreshTokenRequest request)
        {
            var body = new Dictionary<string, string> {
                { "grant_type", "refresh_token" },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret },
                { "refresh_token", request.RefreshToken }
            };

            body.AddIfNotEmpty("audience", request.Audience);
            body.AddIfNotEmpty("scope", request.Scope);

            var response = await connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Perform authentication by providing user-supplied information in a <see cref="ResourceOwnerTokenRequest"/>.
        /// </summary>
        /// <param name="request"><see cref="ResourceOwnerTokenRequest"/> containing information regarding the username, password etc.</param>
        /// <returns><see cref="AccessTokenResponse"/> containing the desired token information.</returns>
        /// <remarks>
        /// The grant_type parameter required by the /oauth/token endpoint will automatically be inferred from the <paramref name="request"/> parameter. If no Realm was specified,
        /// then the grant_type will be set to "password". If a Realm was specified, then the grant_type will be set to "http://auth0.com/oauth/grant-type/password-realm"
        /// </remarks>
        public async Task<AccessTokenResponse> GetTokenAsync(ResourceOwnerTokenRequest request)
        {
            var body = new Dictionary<string, string> {
                { "client_id", request.ClientId },
                { "username", request.Username },
                { "password", request.Password },
                { "scope", request.Scope }
            };

            body.AddIfNotEmpty("client_secret", request.ClientSecret);
            body.AddIfNotEmpty("audience", request.Audience);
            body.AddIfNotEmpty("realm", request.Realm);
            body.Add("grant_type", String.IsNullOrEmpty(request.Realm) ? "password" : "http://auth0.com/oauth/grant-type/password-realm");

            var headers = String.IsNullOrEmpty(request.ForwardedForIp) ? null
                : new Dictionary<string, string> { { "auth0-forwarded-for", request.ForwardedForIp } };

            var response = await connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body,
                headers
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId).ConfigureAwait(false);

            return response;
        }

        /// <summary>
        /// Returns user information based on the access token that was obtained during login.
        /// </summary>
        /// <param name="accessToken">Access token used to obtain the user information.</param>
        /// <returns><see cref="UserInfo"/> associated with the token.</returns>
        /// <remarks>Information included in the response depends on the scopes requested.</remarks>
        public Task<UserInfo> GetUserInfoAsync(string accessToken)
        {
            return connection.GetAsync<UserInfo>(BuildUri("userinfo"), BuildHeaders(accessToken));
        }

        /// <summary>
        /// Returns the WS-Federation metadata.
        /// </summary>
        /// <returns>WS-Federation metadata in XML as a string.</returns>
        public Task<string> GetWsFedMetadataAsync()
        {
            return connection.GetAsync<string>(BuildUri("wsfed/FederationMetadata/2007-06/FederationMetadata.xml"));
        }

        /// <summary>
        /// Create a new user given the user details specified.
        /// </summary>
        /// <param name="request"><see cref="SignupUserRequest" /> containing information of the user to sign up.</param>
        /// <returns><see cref="SignupUserResponse" /> with the information of the signed up user.</returns>
        public Task<SignupUserResponse> SignupUserAsync(SignupUserRequest request)
        {
            return connection.SendAsync<SignupUserResponse>(
                HttpMethod.Post,
                BuildUri("dbconnections/signup"),
                request);
        }

        /// <summary>
        /// Starts a new Passwordless email flow.
        /// </summary>
        /// <param name="request">The <see cref="PasswordlessEmailRequest" /> containing the information about the new Passwordless flow to start.</param>
        /// <returns>A <see cref="PasswordlessEmailResponse" /> containing the response.</returns>
        public Task<PasswordlessEmailResponse> StartPasswordlessEmailFlowAsync(PasswordlessEmailRequest request)
        {
            var body = new
            {
                client_id = request.ClientId,
                connection = "email",
                email = request.Email,
                send = request.Type.ToString().ToLower(),
                authParams = request.AuthenticationParameters
            };

            return connection.SendAsync<PasswordlessEmailResponse>(
                HttpMethod.Post,
                BuildUri("passwordless/start"),
                body);
        }

        /// <summary>
        /// Starts a new Passwordless SMS flow.
        /// </summary>
        /// <param name="request">The <see cref="PasswordlessSmsRequest" /> containing the information about the new Passwordless flow to start.</param>
        /// <returns>A <see cref="PasswordlessSmsResponse" /> containing the response.</returns>
        public Task<PasswordlessSmsResponse> StartPasswordlessSmsFlowAsync(PasswordlessSmsRequest request)
        {
            var body = new
            {
                client_id = request.ClientId,
                connection = "sms",
                phone_number = request.PhoneNumber
            };

            return connection.SendAsync<PasswordlessSmsResponse>(
                HttpMethod.Post,
                BuildUri("passwordless/start"),
                body);
        }

        /// <summary>
        /// Unlinks a secondary account from a primary account.
        /// </summary>
        /// <param name="request">The <see cref="UnlinkUserRequest"/> containing the information of the accounts to unlink.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous unlink operation.</returns>
        public Task UnlinkUserAsync(UnlinkUserRequest request)
        {
            return connection.SendAsync<object>(HttpMethod.Post, BuildUri("unlink"), request);
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as a <see cref="IAuthenticationConnection"/>.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false")/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                if (connection is IDisposable disposableConnection)
                    disposableConnection.Dispose();
                disposed = true;
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as a <see cref="IAuthenticationConnection"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private async Task AssertIdTokenValid(string idToken, string issuer)
        {
            var requirements = new IdTokenRequirements(baseUri.AbsoluteUri, issuer, TimeSpan.FromMinutes(1));
            await requirements.AssertTokenMeetsRequirements(idToken);
        }

        private Uri BuildUri(string path)
        {
            return new UriBuilder(baseUri) { Path = path }.Uri;
        }

        private IDictionary<string, string> BuildHeaders(string accessToken)
        {
            return new Dictionary<string, string> { { "Authorization", "Bearer " + accessToken } };
        }
    }
}
