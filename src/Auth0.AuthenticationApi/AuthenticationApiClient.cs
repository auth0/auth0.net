using Auth0.AuthenticationApi.Builders;
using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Tokens;
using Auth0.Core.Http;
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
        private readonly Uri _baseUri;
        private readonly ApiConnection _apiConnection;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">Your Auth0 domain URI, e.g. https://tenant.auth0.com</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests.</param>
        public AuthenticationApiClient(Uri baseUri, HttpMessageHandler handler = null)
        {
            _baseUri = baseUri;
            _apiConnection = new ApiConnection(null, baseUri.AbsoluteUri, handler);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">Your Auth0 domain URI, e.g. https://tenant.auth0.com</param>
        /// <param name="httpClient">The <see cref="HttpClient"/> which is used for HTTP requests.</param>
        public AuthenticationApiClient(Uri baseUri, HttpClient httpClient)
        {
            _baseUri = baseUri;
            _apiConnection = new ApiConnection(null, baseUri.AbsoluteUri, httpClient);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="domain">Your Auth0 domain, e.g. tenant.auth0.com.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public AuthenticationApiClient(string domain, HttpMessageHandler handler = null)
            : this(new Uri($"https://{domain}"), handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="httpClient">The <see cref="HttpClient"/> which is used for HTTP requests</param>
        public AuthenticationApiClient(string domain, HttpClient httpClient)
            : this(new Uri($"https://{domain}"), httpClient)
        {
        }

        /// <summary>
        /// The <see cref="IApiConnection" /> used to communicate between the client and the Auth0 API.
        /// </summary>
        /// <value>The connection.</value>
        public IApiConnection Connection { get { return _apiConnection; } }

        /// <summary>
        /// Creates a <see cref="AuthorizationUrlBuilder" /> which is used to build an authorization URL.
        /// </summary>
        /// <returns>A new <see cref="AuthorizationUrlBuilder" /> instance.</returns>
        public AuthorizationUrlBuilder BuildAuthorizationUrl()
        {
            return new AuthorizationUrlBuilder(_baseUri.ToString());
        }

        /// <summary>
        /// Creates a <see cref="LogoutUrlBuilder" /> which is used to build a logout URL.
        /// </summary>
        /// <returns>A new <see cref="LogoutUrlBuilder" /> instance.</returns>
        public LogoutUrlBuilder BuildLogoutUrl()
        {
            return new LogoutUrlBuilder(_baseUri.ToString());
        }

        /// <summary>
        /// Creates a <see cref="SamlUrlBuilder" /> which is used to build a SAML authentication URL.
        /// </summary>
        /// <param name="client">The name of the client.</param>
        /// <returns>A new <see cref="SamlUrlBuilder" /> instance.</returns>
        public SamlUrlBuilder BuildSamlUrl(string client)
        {
            return new SamlUrlBuilder(_baseUri.ToString(), client);
        }

        /// <summary>
        /// Creates a <see cref="WsFedUrlBuilder" /> which is used to build a WS-FED authentication URL.
        /// </summary>
        /// <returns>A new <see cref="WsFedUrlBuilder" /> instance.</returns>
        public WsFedUrlBuilder BuildWsFedUrl()
        {
            return new WsFedUrlBuilder(_baseUri.ToString());
        }

        /// <summary>
        /// Given the user's details, Auth0 will send a forgot password email.
        /// </summary>
        /// <param name="request">The <see cref="ChangePasswordRequest" /> specifying the user and connection details.</param>
        /// <returns>A string containing the message returned from Auth0.</returns>
        public Task<string> ChangePasswordAsync(ChangePasswordRequest request)
        {
            return Connection.PostAsync<string>("dbconnections/change_password", request, null, null, null, null, null);
        }

        /// <summary>
        /// Generates a link that can be used once to log in as a specific user.
        /// </summary>
        /// <param name="request">The <see cref="ImpersonationRequest"/> containing the details of the user to impersonate.</param>
        /// <returns>A <see cref="Uri"/> which can be used to sign in as the specified user.</returns>
        public async Task<Uri> GetImpersonationUrlAsync(ImpersonationRequest request)
        {
            string url = await Connection.PostAsync<string>("users/{impersonate_id}/impersonate",
                new
                {
                    protocol = request.Protocol,
                    impersonator_id = request.ImpersonatorId,
                    client_id = request.ClientId,
                    response_type = request.ResponseType,
                    state = request.State
                }, null, null,
                new Dictionary<string, string>
                {
                    {"impersonate_id", request.ImpersonateId}
                },
                new Dictionary<string, object>
                {
                    {"Authorization", $"Bearer {request.Token}"}
                }, null).ConfigureAwait(false);

            return new Uri(url);
        }

        /// <summary>
        /// Returns the SAML 2.0 meta data for a client.
        /// </summary>
        /// <param name="clientId">The client (App) ID for which meta data must be returned.</param>
        /// <returns>The meta data XML .</returns>
        public Task<string> GetSamlMetadataAsync(string clientId)
        {
            return Connection.GetAsync<string>("wsfed/{clientid}", new Dictionary<string, string>
            {
                {"clientid", clientId}
            }, null, null);
        }

        /// <summary>
        /// Request an Access Token using the Authorization Code Grant flow.
        /// </summary>
        /// <param name="request">The <see cref="AuthorizationCodeTokenRequest"/> containing the information of the request.</param>
        /// <returns>An <see cref="AccessTokenResponse"/> containing the token information</returns>
        public async Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodeTokenRequest request)
        {
            var response = await Connection.PostAsync<AccessTokenResponse>("oauth/token", null, new Dictionary<string, object>
            {
                {"grant_type", "authorization_code"},
                {"client_id", request.ClientId},
                {"client_secret", request.ClientSecret},
                {"code", request.Code},
                {"redirect_uri", request.RedirectUri},
            },
                null,
                null,
                null,
                null).ConfigureAwait(false);

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
            var response = await Connection.PostAsync<AccessTokenResponse>("oauth/token", null, new Dictionary<string, object>
            {
                {"grant_type", "authorization_code"},
                {"client_id", request.ClientId},
                {"code", request.Code},
                {"code_verifier", request.CodeVerifier},
                {"redirect_uri", request.RedirectUri}
            },
                null,
                null,
                null,
                null).ConfigureAwait(false);

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
            return Connection.PostAsync<AccessTokenResponse>("oauth/token", null, new Dictionary<string, object>
                {
                    {"grant_type", "client_credentials"},
                    {"client_id", request.ClientId},
                    {"client_secret", request.ClientSecret},
                    {"audience", request.Audience}
                },
                null,
                null,
                null,
                null);
        }

        /// <summary>
        /// Given a <see cref="RefreshTokenRequest"/>, it will retrieve a refreshed access token from the authorization server.
        /// </summary>
        /// <param name="request">The refresh token request details, containing a valid refresh token.</param>
        /// <returns>The new token issued by the server.</returns>
        public async Task<AccessTokenResponse> GetTokenAsync(RefreshTokenRequest request)
        {
            var parameters = new Dictionary<string, object> {
                { "grant_type", "refresh_token" },
                { "refresh_token", request.RefreshToken },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret }
            };

            if (!string.IsNullOrEmpty(request.Audience))
            {
                parameters.Add("audience", request.Audience);
            }

            if (!string.IsNullOrEmpty(request.Scope))
            {
                parameters.Add("scope", request.Scope);
            }
            var response = await Connection.PostAsync<AccessTokenResponse>("oauth/token", null, parameters, null, null, null, null).ConfigureAwait(false);

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
            var parameters = new Dictionary<string, object>
            {
                { "client_id", request.ClientId },
                { "username", request.Username },
                { "password", request.Password },
                { "scope", request.Scope }
            };

            if (!string.IsNullOrEmpty(request.ClientSecret))
            {
                parameters.Add("client_secret", request.ClientSecret);
            }

            if (!string.IsNullOrEmpty(request.Audience))
            {
                parameters.Add("audience", request.Audience);
            }

            if (string.IsNullOrEmpty(request.Realm))
            {
                parameters.Add("grant_type", "password");
            }
            else
            {
                parameters.Add("grant_type", "http://auth0.com/oauth/grant-type/password-realm");
                parameters.Add("realm", request.Realm);
            }

            var headers = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(request.ForwardedForIp))
            {
                headers.Add("auth0-forwarded-for", request.ForwardedForIp);
            }

            var response = await Connection.PostAsync<AccessTokenResponse>("oauth/token", null, parameters, null, null, headers, null).ConfigureAwait(false);

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
            return Connection.GetAsync<UserInfo>("userinfo", null, null, new Dictionary<string, object>
            {
                {"Authorization", $"Bearer {accessToken}"}
            });
        }

        /// <summary>
        /// Returns the WS Federation meta data.
        /// </summary>
        /// <returns>The meta data XML</returns>
        public Task<string> GetWsFedMetadataAsync()
        {
            return Connection.GetAsync<string>("wsfed/FederationMetadata/2007-06/FederationMetadata.xml", null, null, null);
        }

        /// <summary>
        /// Given the user credentials, the connection specified and the Auth0 account information, it will create a new user.
        /// </summary>
        /// <param name="request">The <see cref="SignupUserRequest" /> containing information of the user to sign up.</param>
        /// <returns>A <see cref="SignupUserResponse" /> with the information of the signed up user.</returns>
        public Task<SignupUserResponse> SignupUserAsync(SignupUserRequest request)
        {
            return Connection.PostAsync<SignupUserResponse>("dbconnections/signup", request, null, null, null, null, null);
        }

        /// <summary>
        /// Starts a new Passwordless email flow.
        /// </summary>
        /// <param name="request">The <see cref="PasswordlessEmailRequest" /> containing the information about the new Passwordless flow to start.</param>
        /// <returns>A <see cref="PasswordlessEmailResponse" /> containing the response.</returns>
        public Task<PasswordlessEmailResponse> StartPasswordlessEmailFlowAsync(PasswordlessEmailRequest request)
        {
            return Connection.PostAsync<PasswordlessEmailResponse>("passwordless/start",
                new
                {
                    client_id = request.ClientId,
                    connection = "email",
                    email = request.Email,
                    send = request.Type.ToString().ToLower(),
                    authParams = request.AuthenticationParameters
                },
                null, null, null, null, null);
        }

        /// <summary>
        /// Starts a new Passwordless SMS flow.
        /// </summary>
        /// <param name="request">The <see cref="PasswordlessSmsRequest" /> containing the information about the new Passwordless flow to start.</param>
        /// <returns>A <see cref="PasswordlessSmsResponse" /> containing the response.</returns>
        public Task<PasswordlessSmsResponse> StartPasswordlessSmsFlowAsync(PasswordlessSmsRequest request)
        {
            return Connection.PostAsync<PasswordlessSmsResponse>("passwordless/start",
                new
                {
                    client_id = request.ClientId,
                    connection = "sms",
                    phone_number = request.PhoneNumber
                },
                null, null, null, null, null);
        }

        /// <summary>
        /// Unlinks a secondary account from a primary account.
        /// </summary>
        /// <param name="request">The <see cref="UnlinkUserRequest"/> containing the information of the accounts to unlink.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous unlink operation.</returns>
        public async Task UnlinkUserAsync(UnlinkUserRequest request)
        {
            await Connection.PostAsync<object>("unlink", request, null, null, null, null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as the ApiConnection.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false")/>.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                _apiConnection.Dispose();
                disposed = true;
            }
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as the ApiConnection.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        private async Task AssertIdTokenValid(string idToken, string issuer)
        {
            var requirements = new IdTokenRequirements(_baseUri.AbsoluteUri, issuer, TimeSpan.FromMinutes(1));
            await requirements.AssertTokenMeetsRequirements(idToken);
        }
    }
}
