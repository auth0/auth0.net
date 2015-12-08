using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Builders;
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

        public AuthorizationUrlBuilder BuildAuthorizationUrl()
        {
            return new AuthorizationUrlBuilder(baseUri.ToString());
        }

        public LogoutUrlBuilder BuildLogoutUrl()
        {
            return new LogoutUrlBuilder(baseUri.ToString());
        }

        public SamlUrlBuilder BuildSamlUrl(string client)
        {
            return new SamlUrlBuilder(baseUri.ToString(), client);
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