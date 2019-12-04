using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Tokens;
using Microsoft.IdentityModel.Tokens;
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
    /// Full documentation on the Auth0 Authentication API is available at https://auth0.com/docs/api/authentication
    /// </remarks>
    public class AuthenticationApiClient : IAuthenticationApiClient, IDisposable
    {
        readonly TimeSpan idTokenValidationLeeway = TimeSpan.FromMinutes(1);
        readonly Uri tokenUri;
        readonly IAuthenticationConnection connection;
        bool disposed = false;

        /// <inheritdoc />
        public Uri BaseUri { get; private set; }

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
            BaseUri = baseUri;
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

        /// <inheritdoc />
        public Task<string> ChangePasswordAsync(ChangePasswordRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return connection.SendAsync<string>(
                HttpMethod.Post,
                BuildUri("dbconnections/change_password"),
                request);
        }

        /// <inheritdoc />
        public async Task<Uri> GetImpersonationUrlAsync(ImpersonationRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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

        /// <inheritdoc />
        public Task<UserInfo> GetUserInfoAsync(string accessToken)
        {
            if (accessToken == null)
                throw new ArgumentNullException(nameof(accessToken));

            return connection.GetAsync<UserInfo>(BuildUri("userinfo"), BuildHeaders(accessToken));
        }

        /// <inheritdoc />
        public async Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodeTokenRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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

            await AssertIdTokenValid(response.IdToken, request.ClientId, request.SigningAlgorithm, request.ClientSecret).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc/>
        public async Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodePkceTokenRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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

            await AssertIdTokenValid(response.IdToken, request.ClientId, request.SigningAlgorithm, request.ClientSecret).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc/>
        public Task<AccessTokenResponse> GetTokenAsync(ClientCredentialsTokenRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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

        /// <inheritdoc/>
        public async Task<AccessTokenResponse> GetTokenAsync(RefreshTokenRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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

            await AssertIdTokenValid(response.IdToken, request.ClientId, request.SigningAlgorithm, request.ClientSecret).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc/>
        public async Task<AccessTokenResponse> GetTokenAsync(ResourceOwnerTokenRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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

            await AssertIdTokenValid(response.IdToken, request.ClientId, request.SigningAlgorithm, request.ClientSecret).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc/>
        public Task<SignupUserResponse> SignupUserAsync(SignupUserRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return connection.SendAsync<SignupUserResponse>(
                HttpMethod.Post,
                BuildUri("dbconnections/signup"),
                request);
        }

        /// <inheritdoc/>
        public Task<PasswordlessEmailResponse> StartPasswordlessEmailFlowAsync(PasswordlessEmailRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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

        /// <inheritdoc/>
        public Task<PasswordlessSmsResponse> StartPasswordlessSmsFlowAsync(PasswordlessSmsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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
            GC.SuppressFinalize(this);
        }

        private Task AssertIdTokenValid(string idToken, string audience, JwtSignatureAlgorithm algorithm, string clientSecret)
        {
            var requirements = new IdTokenRequirements(algorithm, BaseUri.AbsoluteUri, audience, idTokenValidationLeeway);
            return new IdTokenValidator().Assert(requirements, idToken, clientSecret);
        }

        private Uri BuildUri(string path)
        {
            return new UriBuilder(BaseUri) { Path = path }.Uri;
        }

        private IDictionary<string, string> BuildHeaders(string accessToken)
        {
            return new Dictionary<string, string> { { "Authorization", "Bearer " + accessToken } };
        }
    }
}
