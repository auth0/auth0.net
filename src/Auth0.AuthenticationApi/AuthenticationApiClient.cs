using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Builders;
using Auth0.AuthenticationApi.Models;
using Auth0.Core;
using Auth0.Core.Http;

namespace Auth0.AuthenticationApi
{
    /// <summary>
    /// Client for communicating with the Auth0 Authentication API.
    /// </summary>
    /// <remarks>
    /// Full documentation for the Authentication API is available at https://auth0.com/docs/auth-api
    /// </remarks>
    public class AuthenticationApiClient : IAuthenticationApiClient
    {
        /// <summary>
        /// The API connection
        /// </summary>
        private readonly IApiConnection apiConnection;

        /// <summary>
        /// The base URI
        /// </summary>
        private readonly Uri baseUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public AuthenticationApiClient(Uri baseUri, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
        {
            this.baseUri = baseUri;

            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            apiConnection = new ApiConnection(null, baseUri.AbsoluteUri, diagnostics, handler);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public AuthenticationApiClient(Uri baseUri, HttpMessageHandler handler)
            : this(baseUri, null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        public AuthenticationApiClient(Uri baseUri, DiagnosticsHeader diagnostics)
            : this(baseUri, diagnostics, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        public AuthenticationApiClient(Uri baseUri)
            : this(baseUri, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="domain">Your Auth0 domain, e.g. mydomain.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public AuthenticationApiClient(string domain, DiagnosticsHeader diagnostics, HttpMessageHandler handler)
            : this(new Uri($"https://{domain}"), diagnostics, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="domain">Your Auth0 domain, e.g. mydomain.auth0.com.</param>
        /// <param name="handler">The <see cref="HttpMessageHandler"/> which is used for HTTP requests</param>
        public AuthenticationApiClient(string domain, HttpMessageHandler handler)
            : this(new Uri($"https://{domain}"), null, handler)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="domain">Your Auth0 domain, e.g. mydomain.auth0.com.</param>
        /// <param name="diagnostics">The diagnostics.</param>
        public AuthenticationApiClient(string domain, DiagnosticsHeader diagnostics)
            : this(new Uri($"https://{domain}"), diagnostics, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="domain">Your Auth0 domain, e.g. mydomain.auth0.com.</param>
        public AuthenticationApiClient(string domain)
            : this(new Uri($"https://{domain}"), null, null)
        {
        }

        /// <summary>
        /// The <see cref="IApiConnection" /> used to communicate between the client and the Auth0 API.
        /// </summary>
        /// <value>The connection.</value>
        public IApiConnection Connection
        {
            get { return apiConnection; }
        }

        /// <summary>
        /// Given an <see cref="AuthenticationRequest" />, it will do the authentication on the provider and return an <see cref="AccessToken"./>
        /// </summary>
        /// <param name="request">The authentication request details containing information regarding the connection, username, password etc.</param>
        /// <returns>An <see cref="AccessToken" /> with the response.</returns>
        public Task<AccessToken> AuthenticateAsync(AuthenticationRequest request)
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

            if (string.IsNullOrEmpty(request.Realm))
            {
                parameters.Add("grant_type", "password");
            }
            else
            {
                parameters.Add("grant_type", "http://auth0.com/oauth/grant-type/password-realm");
                parameters.Add("realm", request.Realm);
            }

            return Connection.PostAsync<AccessToken>("oauth/token", null, parameters, null, null, null, null);
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
            return Connection.PostAsync<string>("dbconnections/change_password", request, null, null, null, null, null);
        }

        /// <summary>
        /// Exhanges an OAuth authorization code for an access token. This needs to be called as part of the OAuth authentication process, after the user has
        /// authenticated and the redirect URI is called with an authorization code. 
        /// </summary>
        /// <param name="request">The <see cref="ExchangeCodeRequest"/> containing the authorization code and other information needed to exchange the code for an access token.</param>
        /// <returns></returns>
        public Task<AccessToken> ExchangeCodeForAccessTokenAsync(ExchangeCodeRequest request)
        {
            return Connection.PostAsync<AccessToken>("oauth/token", null, new Dictionary<string, object>
            {
                {"client_id", request.ClientId},
                {"redirect_uri", request.RedirectUri},
                {"client_secret", request.ClientSecret},
                {"code", request.AuthorizationCode},
                {"grant_type", "authorization_code"}
            },
                null,
                null,
                null,
                null);
        }

        /// <summary>
        /// Given an existing token, this endpoint will generate a new token signed with the target client secret. This is used to flow the identity of the user from the application to an API or across different APIs that are protected with different secrets.
        /// </summary>
        /// <param name="request">The <see cref="DelegationRequestBase" /> containing details about the request.</param>
        /// <returns>The <see cref="AccessToken" />.</returns>
        public Task<AccessToken> GetDelegationTokenAsync(DelegationRequestBase request)
        {
            return Connection.PostAsync<AccessToken>("delegation", request, null, null, null, null, null);
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
                    {"Authorization", string.Format("Bearer {0}", request.Token)}
                }, null);

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
        /// Returns the user information based on the Auth0 access token (obtained during login).
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>The <see cref="User" /> associated with the token.</returns>
        public Task<UserInfo> GetUserInfoAsync(string accessToken)
        {
            return Connection.GetAsync<UserInfo>("userinfo", null, null, new Dictionary<string, object>
            {
                {"Authorization", string.Format("Bearer {0}", accessToken)}
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
        /// <returns>Nothing</returns>
        public async Task UnlinkUserAsync(UnlinkUserRequest request)
        {
            await Connection.PostAsync<object>("unlink", request, null, null, null, null, null);
        }

        /// <summary>
        /// Given an <see cref="UsernamePasswordLoginRequest"/>, it will do the authentication on the provider and return a <see cref="UsernamePasswordLoginResponse"/>
        /// </summary>
        /// <param name="request">The authentication request details containing information regarding the connection, username, password etc.</param>
        /// <returns>A <see cref="UsernamePasswordLoginResponse"/> containing the WS-Federation Login Form, which can be posted by the user to trigger a server-side login.</returns>
        public async Task<UsernamePasswordLoginResponse> UsernamePasswordLoginAsync(UsernamePasswordLoginRequest request)
        {
            if (request != null && string.IsNullOrEmpty(request.Tenant) && baseUri.Host.Contains("."))
            {
                request.Tenant = baseUri.Host.Split('.')[0];
            }

            if (request != null && string.IsNullOrEmpty(request.ResponseType))
            {
                request.ResponseType = "code";
            }

            return new UsernamePasswordLoginResponse()
            {
                HtmlForm = await Connection.PostAsync<string>("usernamepassword/login", request, null, null, null, null, null).ConfigureAwait(false)
            };
        }

        /// <summary>
        /// Given a <see cref="TokenRefreshRequest"/>, it will retrieve a refreshed access token from the authorization server.
        /// </summary>
        /// <param name="request">The refresh token request details, containing a valid refresh token.</param>
        /// <returns>The new token issued by the server.</returns>
        public async Task<AccessToken> GetRefreshedTokenAsync(TokenRefreshRequest request)
        {
            var parameters = new Dictionary<string, object> {
                { "grant_type", "refresh_token" },
                { "refresh_token", request.RefreshToken },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret }
            };

            if (!string.IsNullOrEmpty(request.Scope))
            {
                parameters.Add("scope", request.Scope);
            }
            return await Connection.PostAsync<AccessToken>("oauth/token", null, parameters, null, null, null, null);
        }
    }
}