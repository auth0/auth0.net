using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;
using Auth0.Core;
using Auth0.Core.Http;

namespace Auth0.AuthenticationApi.Client
{
    public class AuthenticationApiClient : IAuthenticationApiClient
    {
        private readonly Uri baseUri;
        private readonly IApiConnection apiConnection;

        public AuthenticationApiClient(Uri baseUri, DiagnosticsHeader diagnostics)
        {
            this.baseUri = baseUri;

            // If no diagnostics header structure was specified, then revert to the default one
            if (diagnostics == null)
            {
                diagnostics = DiagnosticsHeader.Default;
            }

            apiConnection = new ApiConnection(null, baseUri.AbsoluteUri, diagnostics);
        }

        public AuthenticationApiClient(Uri baseUri)
            : this(baseUri, null)
        {
            
        }

        public IApiConnection Connection
        {
            get { return apiConnection; }
        }

        public Task<Uri> BuildAuthorizationUri(BuildAuthorizationUriRequest request)
        {
            IDictionary<string, string> queryStrings = new Dictionary<string, string>();
            queryStrings.Add("response_type", request.ResponseType.ToString().ToLower());
            if (!string.IsNullOrEmpty(request.ClientId))
                queryStrings.Add("client_id", request.ClientId);
            if (!string.IsNullOrEmpty(request.Connection))
                queryStrings.Add("connection", request.Connection);
            if (request.RedirectUri != null)
                queryStrings.Add("redirect_uri", request.RedirectUri.ToString());
            if (!string.IsNullOrEmpty(request.State))
                queryStrings.Add("state", request.State);
            if (!string.IsNullOrEmpty(request.Scope))
                queryStrings.Add("scope", request.Scope);
            if (!string.IsNullOrEmpty(request.Device))
                queryStrings.Add("device", request.Device);

            return Task.FromResult(Utils.BuildUri(baseUri.ToString(), "authorize", null, queryStrings));
        }

        public Task<Uri> BuildLogoutUri(Uri returnUri)
        {
            Dictionary<string, string> queryStrings = new Dictionary<string, string>();
            if (returnUri != null)
                queryStrings.Add("returnTo", returnUri.ToString());

            return Task.FromResult(Utils.BuildUri(baseUri.ToString(), "logout", null, queryStrings));
        }

        public Task<string> ChangePassword(ChangePasswordRequest request)
        {
            return Connection.PostAsync<string>("dbconnections/change_password", request, null, null, null, null, null);
        }

        public Task<AccessToken> GetAccessToken(AccessTokenRequest request)
        {
            return Connection.PostAsync<AccessToken>("oauth/access_token", request, null, null, null, null, null);
        }

        public Task<AccessToken> GetDelegationToken(DelegationRequestBase request)
        {
            return Connection.PostAsync<AccessToken>("delegation", request, null, null, null, null, null);
        }

        public Task<User> GetUserInfo(string accessToken)
        {
            return Connection.GetAsync<User>("userinfo", null, null, new Dictionary<string, object>
                {
                    { "Authorization", string.Format("Bearer {0}", accessToken) }
                });
        }

        public Task<User> GetTokenInfo(string idToken)
        {
            return Connection.PostAsync<User>("tokeninfo", 
                new
                {
                    id_token = idToken
                }, null, null, null, null, null);
        }

        public Task<SignupUserResponse> SignupUser(SignupUserRequest request)
        {
            return Connection.PostAsync<SignupUserResponse>("dbconnections/signup", request, null, null, null, null, null);
        }

        public Task<PasswordlessEmailResponse> StartPasswordlessEmailFlow(PasswordlessEmailRequest request)
        {
            return Connection.PostAsync<PasswordlessEmailResponse>("passwordless/start", 
                new
                {
                    client_id = request.ClientId,
                    connection  = "email",
                    email = request.Email,
                    send = request.Type.ToString().ToLower(),
                    authParams = request.AuthenticationParameters
                }, 
                null, null, null, null, null);
        }

        public Task<PasswordlessSmsResponse> StartPasswordlessSmsFlow(PasswordlessSmsRequest request)
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

        public Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            return Connection.PostAsync<AuthenticationResponse>("oauth/ro", request, null, null, null, null, null);
        }
    }
}