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
    /// Client for communicating with the Auth0 Authentication API.
    /// </summary>
    /// <remarks>
    /// Full documentation for the Authentication API is available at https://auth0.com/docs/auth-api
    /// </remarks>
    public class AuthenticationApiClient : IAuthenticationApiClient, IDisposable
    {
        private readonly Uri baseUri;
        private readonly IAuthenticationConnection connection;
        private bool shouldDisposeConnection = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">Your Auth0 domain URI, e.g. https://tenant.auth0.com</param>
        /// <param name="connection">Optional <see cref="IAuthenticationConnection"/> used to make API requests.</param>
        public AuthenticationApiClient(Uri baseUri, IAuthenticationConnection connection = null)
        {
            this.baseUri = baseUri;
            this.connection = connection ?? new HttpClientAuthenticationConnection();
            shouldDisposeConnection = connection == null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">Your Auth0 domain name, e.g. tenant.auth0.com</param>
        /// <param name="connection">Optional <see cref="IAuthenticationConnection"/> used to make API requests.</param>
        public AuthenticationApiClient(string domain, IAuthenticationConnection connection = null)
            : this(new Uri($"https://{domain}"), connection)
        {
        }

        /// <summary>
        /// Creates a <see cref="AuthorizationUrlBuilder" /> which is used to build an authorization URL.
        /// </summary>
        /// <returns>A new <see cref="AuthorizationUrlBuilder" /> instance.</returns>
        public AuthorizationUrlBuilder BuildAuthorizationUrl()
        {
            return new AuthorizationUrlBuilder(baseUri.ToString());
        }

        /// <summary>
        /// Creates a <see cref="LogoutUrlBuilder" /> which is used to build a logout URL.
        /// </summary>
        /// <returns>A new <see cref="LogoutUrlBuilder" /> instance.</returns>
        public LogoutUrlBuilder BuildLogoutUrl()
        {
            return new LogoutUrlBuilder(baseUri.ToString());
        }

        /// <summary>
        /// Creates a <see cref="SamlUrlBuilder" /> which is used to build a SAML authentication URL.
        /// </summary>
        /// <param name="client">The name of the client.</param>
        /// <returns>A new <see cref="SamlUrlBuilder" /> instance.</returns>
        public SamlUrlBuilder BuildSamlUrl(string client)
        {
            return new SamlUrlBuilder(baseUri.ToString(), client);
        }

        /// <summary>
        /// Creates a <see cref="WsFedUrlBuilder" /> which is used to build a WS-FED authentication URL.
        /// </summary>
        /// <returns>A new <see cref="WsFedUrlBuilder" /> instance.</returns>
        public WsFedUrlBuilder BuildWsFedUrl()
        {
            return new WsFedUrlBuilder(baseUri.ToString());
        }

        /// <summary>
        /// Given the user's details, Auth0 will send a forgot password email.
        /// </summary>
        /// <param name="request">The <see cref="ChangePasswordRequest" /> specifying the user and connection details.</param>
        /// <returns>A string containing the message returned from Auth0.</returns>
        public Task<string> ChangePasswordAsync(ChangePasswordRequest request)
        {
            return connection.SendAsync<string>(
                HttpMethod.Post,
                BuildUri("dbconnections/change_password"),
                request);
        }

        /// <summary>
        /// Generates a link that can be used once to log in as a specific user.
        /// </summary>
        /// <param name="request">The <see cref="ImpersonationRequest"/> containing the details of the user to impersonate.</param>
        /// <returns>A <see cref="Uri"/> which can be used to sign in as the specified user.</returns>
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
        /// Returns the SAML 2.0 meta data for a client.
        /// </summary>
        /// <param name="clientId">The client (App) ID for which meta data must be returned.</param>
        /// <returns>The meta data XML .</returns>
        public Task<string> GetSamlMetadataAsync(string clientId)
        {
            return connection.GetAsync<string>(BuildUri($"wsfed/{clientId}"));
        }

        /// <summary>
        /// Request an Access Token using the Authorization Code Grant flow.
        /// </summary>
        /// <param name="request">The <see cref="AuthorizationCodeTokenRequest"/> containing the information of the request.</param>
        /// <returns>An <see cref="AccessTokenResponse"/> containing the token information</returns>
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
                BuildUri("oauth/token"),
                body
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId);

            return response;
        }

        /// <summary>
        /// Request an Access Token using the Authorization Code (PKCE) flow.
        /// </summary>
        /// <param name="request">The <see cref="AuthorizationCodePkceTokenRequest"/> containing the information of the request.</param>
        /// <returns>An <see cref="AccessTokenResponse"/> containing the token information</returns>
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
                BuildUri("oauth/token"),
                body
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId);

            return response;
        }

        /// <summary>
        /// Request an Access Token using the Client Credentials Grant flow.
        /// </summary>
        /// <param name="request">The <see cref="ClientCredentialsTokenRequest"/> containing the information of the request.</param>
        /// <returns>An <see cref="AccessTokenResponse"/> containing the token information</returns>
        public Task<AccessTokenResponse> GetTokenAsync(ClientCredentialsTokenRequest request)
        {
            var body = new Dictionary<string, string> {
                { "grant_type", "client_credentials" },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret },
                { "audience", request.Audience } };

            return connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                BuildUri("oauth/token"),
                body);
        }

        /// <summary>
        /// Given a <see cref="RefreshTokenRequest"/>, it will retrieve a refreshed access token from the authorization server.
        /// </summary>
        /// <param name="request">The refresh token request details, containing a valid refresh token.</param>
        /// <returns>The new token issued by the server.</returns>
        public async Task<AccessTokenResponse> GetTokenAsync(RefreshTokenRequest request)
        {
            var body = new Dictionary<string, string> {
                { "grant_type", "refresh_token" },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret },
                { "refresh_token", request.RefreshToken }
            };

            if (!string.IsNullOrEmpty(request.Audience))
                body.Add("audience", request.Audience);

            if (!string.IsNullOrEmpty(request.Scope))
                body.Add("scope", request.Scope);

            var response = await connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                BuildUri("oauth/token"),
                body
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId);

            return response;
        }

        /// <summary>
        /// Given an <see cref="ResourceOwnerTokenRequest" />, it will do the authentication on the provider and return an <see cref="AccessTokenResponse"/>.
        /// </summary>
        /// <param name="request">The authentication request details containing information regarding the username, password etc.</param>
        /// <returns>An <see cref="AccessTokenResponse" /> with the response.</returns>
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

            if (!string.IsNullOrEmpty(request.ClientSecret))
                body.Add("client_secret", request.ClientSecret);

            if (!string.IsNullOrEmpty(request.Audience))
                body.Add("audience", request.Audience);

            if (string.IsNullOrEmpty(request.Realm))
            {
                body.Add("grant_type", "password");
            }
            else
            {
                body.Add("grant_type", "http://auth0.com/oauth/grant-type/password-realm");
                body.Add("realm", request.Realm);
            }

            var headers = string.IsNullOrEmpty(request.ForwardedForIp) ? null
                : new Dictionary<string, string> { { "auth0-forwarded-for", request.ForwardedForIp } };

            var response = await connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                BuildUri("oauth/token"),
                body,
                headers
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId);

            return response;
        }

        /// <summary>
        /// Returns the user information based on the Auth0 access token (obtained during login).
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The <see cref="UserInfo"/> associated with the token.</returns>
        public Task<UserInfo> GetUserInfoAsync(string accessToken)
        {
            return connection.GetAsync<UserInfo>(BuildUri("userinfo"), BuildHeaders(accessToken));
        }

        /// <summary>
        /// Returns the WS Federation meta data.
        /// </summary>
        /// <returns>The meta data XML</returns>
        public Task<string> GetWsFedMetadataAsync()
        {
            return connection.GetAsync<string>(BuildUri("wsfed/FederationMetadata/2007-06/FederationMetadata.xml"));
        }

        /// <summary>
        /// Given the user credentials, the connection specified and the Auth0 account information, it will create a new user.
        /// </summary>
        /// <param name="request">The <see cref="SignupUserRequest" /> containing information of the user to sign up.</param>
        /// <returns>A <see cref="SignupUserResponse" /> with the information of the signed up user.</returns>
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
        /// Disposes of any owned disposable resources.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false")/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && shouldDisposeConnection)
            {
                ((IDisposable)connection).Dispose();
                shouldDisposeConnection = false;
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources.
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
