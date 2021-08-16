using Auth0.AuthenticationApi.Models;
using Auth0.AuthenticationApi.Tokens;
using Auth0.Core.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
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
        static readonly IdTokenValidator idTokenValidator = new IdTokenValidator();
        readonly TimeSpan idTokenValidationLeeway = TimeSpan.FromMinutes(1);
        readonly Uri tokenUri;
        protected readonly IAuthenticationConnection connection;        
        IDisposable connectionToDispose;

        /// <inheritdoc />
        public Uri BaseUri { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="baseUri">Your Auth0 domain URI, e.g. https://tenant.auth0.com</param>
        /// <param name="connection">Optional <see cref="IAuthenticationConnection"/> used to influence connection behavior.
        /// Defaults to a freshly created <see cref="HttpClientAuthenticationConnection"/> that uses a single <see cref="HttpClient"/>.</param>
        /// <remarks>To use a custom <see cref="HttpClient"/> or <see cref="HttpMessageHandler"/> create a 
        /// <see cref="HttpClientAuthenticationConnection"/> passing that into the constructor. e.g.
        /// <code>var client = new AuthenticationApiClient(new HttpClientAuthenticationConnection(myHttpClient));</code> or
        /// <code>var client = new AuthenticationApiClient(new HttpClientAuthenticationConnection(myHttpMessageHandler));</code> or
        /// </remarks>
        public AuthenticationApiClient(Uri baseUri, IAuthenticationConnection connection = null)
        {
            BaseUri = baseUri;
            if (connection == null)
            {
                var ownConnection = new HttpClientAuthenticationConnection();
                this.connection = ownConnection;
                connectionToDispose = ownConnection;
            }
            else
            {
                this.connection = connection;
            }

            tokenUri = BuildUri("oauth/token");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationApiClient" /> class.
        /// </summary>
        /// <param name="domain">Your Auth0 domain name, e.g. tenant.auth0.com.</param>
        /// <param name="connection">Optional <see cref="IAuthenticationConnection"/> used to influence connection behavior.
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
        public Task<string> ChangePasswordAsync(ChangePasswordRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return connection.SendAsync<string>(
                HttpMethod.Post,
                BuildUri("dbconnections/change_password"),
                request,
                null,
                cancellationToken);
        }

        /// <inheritdoc />
        public async Task<Uri> GetImpersonationUrlAsync(ImpersonationRequest request, CancellationToken cancellationToken = default)
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
                BuildHeaders(request.Token),
                cancellationToken
            ).ConfigureAwait(false);

            return new Uri(response);
        }

        /// <inheritdoc />
        public Task<UserInfo> GetUserInfoAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            if (accessToken == null)
                throw new ArgumentNullException(nameof(accessToken));

            return connection.GetAsync<UserInfo>(BuildUri("userinfo"), BuildHeaders(accessToken), cancellationToken);
        }

        /// <inheritdoc />
        public async Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodeTokenRequest request, CancellationToken cancellationToken = default)
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
                body,
                null,
                cancellationToken
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId, request.SigningAlgorithm, request.ClientSecret, request.Organization).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc/>
        public async Task<AccessTokenResponse> GetTokenAsync(AuthorizationCodePkceTokenRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var body = new Dictionary<string, string> {
                { "grant_type", "authorization_code" },
                { "client_id", request.ClientId },
                { "code", request.Code },
                { "code_verifier", request.CodeVerifier },
                { "redirect_uri", request.RedirectUri } };

            if (!string.IsNullOrEmpty(request.ClientSecret))
            {
                body.Add("client_secret", request.ClientSecret);
            }

            var response = await connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body,
                null,
                cancellationToken
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId, request.SigningAlgorithm, request.ClientSecret, request.Organization).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc/>
        public Task<AccessTokenResponse> GetTokenAsync(ClientCredentialsTokenRequest request, CancellationToken cancellationToken = default)
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
                body,
                null,
                cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<AccessTokenResponse> GetTokenAsync(RefreshTokenRequest request, CancellationToken cancellationToken = default)
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
                body,
                null,
                cancellationToken
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId, request.SigningAlgorithm, request.ClientSecret, request.Organization).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc/>
        public async Task<AccessTokenResponse> GetTokenAsync(ResourceOwnerTokenRequest request, CancellationToken cancellationToken = default)
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
                headers,
                cancellationToken
            ).ConfigureAwait(false);

            await AssertIdTokenValid(response.IdToken, request.ClientId, request.SigningAlgorithm, request.ClientSecret).ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc/>
        public Task<AccessTokenResponse> GetTokenAsync(PasswordlessEmailTokenRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var body = new Dictionary<string, string> {
                { "grant_type", "http://auth0.com/oauth/grant-type/passwordless/otp" },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret },
                { "username", request.Email },
                { "realm", "email" },
                { "otp", request.Code },
                { "audience", request.Audience },
                { "scope", request.Scope } };

            return connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body,
                null,
                cancellationToken);
        }

        /// <inheritdoc/>
        public Task<AccessTokenResponse> GetTokenAsync(PasswordlessSmsTokenRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var body = new Dictionary<string, string> {
                { "grant_type", "http://auth0.com/oauth/grant-type/passwordless/otp" },
                { "client_id", request.ClientId },
                { "client_secret", request.ClientSecret },
                { "username", request.PhoneNumber },
                { "realm", "sms" },
                { "otp", request.Code },
                { "audience", request.Audience },
                { "scope", request.Scope } };

            return connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body,
                null,
                cancellationToken);
        }

        /// <inheritdoc/>
        public Task<AccessTokenResponse> GetTokenAsync(DeviceCodeTokenRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var body = new Dictionary<string, string>
            {
                {"grant_type", "urn:ietf:params:oauth:grant-type:device_code"},
                {"device_code", request.DeviceCode},
                {"client_id", request.ClientId}
            };

            return connection.SendAsync<AccessTokenResponse>(
                HttpMethod.Post,
                tokenUri,
                body,
                null,
                cancellationToken
            );
        }

        /// <inheritdoc/>
        public Task<SignupUserResponse> SignupUserAsync(SignupUserRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return connection.SendAsync<SignupUserResponse>(
                HttpMethod.Post,
                BuildUri("dbconnections/signup"),
                request,
                null,
                cancellationToken);
        }

        /// <inheritdoc/>
        public Task<PasswordlessEmailResponse> StartPasswordlessEmailFlowAsync(PasswordlessEmailRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var body = new
            {
                client_id = request.ClientId,
                client_secret = request.ClientSecret,
                connection = "email",
                email = request.Email,
                send = request.Type.ToString().ToLower(),
                authParams = request.AuthenticationParameters
            };

            return connection.SendAsync<PasswordlessEmailResponse>(
                HttpMethod.Post,
                BuildUri("passwordless/start"),
                body,
                null,
                cancellationToken);
        }

        /// <inheritdoc/>
        public Task<PasswordlessSmsResponse> StartPasswordlessSmsFlowAsync(PasswordlessSmsRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var body = new
            {
                client_id = request.ClientId,
                client_secret = request.ClientSecret,
                connection = "sms",
                phone_number = request.PhoneNumber
            };

            return connection.SendAsync<PasswordlessSmsResponse>(
                HttpMethod.Post,
                BuildUri("passwordless/start"),
                body,
                null,
                cancellationToken);
        }

        /// <inheritdoc/>
        public Task<DeviceCodeResponse> StartDeviceFlowAsync(DeviceCodeRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var body = new Dictionary<string, string>
            {
                {"client_id", request.ClientId},
                {"scope", request.Scope},
                {"audience", request.Audience}
            };

            return connection.SendAsync<DeviceCodeResponse>(
                HttpMethod.Post,
                BuildUri("oauth/device/code"),
                body,
                null,
                cancellationToken
            );
        }

        /// <summary>
        /// Disposes of any owned disposable resources such as a <see cref="IAuthenticationConnection"/>.
        /// </summary>
        /// <param name="disposing">Whether we are actually disposing (<see langword="true"/>) or not (<see langword="false"/>).</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && connectionToDispose != null)
            {
                connectionToDispose.Dispose();
                connectionToDispose = null;
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

        private Task AssertIdTokenValid(string idToken, string audience, JwtSignatureAlgorithm algorithm, string clientSecret, string organization = null)
        {
            var requirements = new IdTokenRequirements(algorithm, BaseUri.AbsoluteUri, audience, idTokenValidationLeeway, null, organization);
            return idTokenValidator.Assert(requirements, idToken, clientSecret);
        }

        private Uri BuildUri(string path)
        {
            return Utils.BuildUri(BaseUri.AbsoluteUri, path, null, null);
        }

        private IDictionary<string, string> BuildHeaders(string accessToken)
        {
            return new Dictionary<string, string> { { "Authorization", "Bearer " + accessToken } };
        }
    }
}
