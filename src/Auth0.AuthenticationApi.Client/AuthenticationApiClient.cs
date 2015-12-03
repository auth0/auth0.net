using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;
using Auth0.Core.Http;
using PortableRest;

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
            RestRequest restRequest = new RestRequest("authorize");
            restRequest.AddQueryString("response_type", request.ResponseType.ToString().ToLower());
            if (!string.IsNullOrEmpty(request.ClientId))
                restRequest.AddQueryString("client_id", request.ClientId);
            if (!string.IsNullOrEmpty(request.Connection))
                restRequest.AddQueryString("connection", request.Connection);
            if (request.RedirectUri != null)
                restRequest.AddQueryString("redirect_uri", request.RedirectUri);
            if (!string.IsNullOrEmpty(request.State))
                restRequest.AddQueryString("state", request.State);
            if (!string.IsNullOrEmpty(request.Scope))
                restRequest.AddQueryString("scope", request.Scope);
            if (!string.IsNullOrEmpty(request.Device))
                restRequest.AddQueryString("device", request.Device);

            return Task.FromResult(restRequest.GetResourceUri(baseUri.ToString()));
        }

        public Task<string> ChangePassword(ChangePasswordRequest request)
        {
            return Connection.PostAsync<string>("dbconnections/change_password", ContentTypes.Json,
                request, null, null, null, null, null);
        }

        public Task<AccessToken> GetAccessToken(AccessTokenRequest request)
        {
            return Connection.PostAsync<AccessToken>("oauth/access_token", ContentTypes.Json,
                request, null, null, null, null, null);
        }

        public Task<AccessToken> GetDelegationToken(DelegationRequestBase request)
        {
            return Connection.PostAsync<AccessToken>("delegation", ContentTypes.Json,
                request, null, null, null, null, null);
        }

        public Task<SignupUserResponse> SignupUser(SignupUserRequest request)
        {
            return Connection.PostAsync<SignupUserResponse>("dbconnections/signup", ContentTypes.Json,
                request, null, null, null, null, null);
        }

        public Task<PasswordlessEmailResponse> StartPasswordlessEmailFlow(PasswordlessEmailRequest request)
        {
            return Connection.PostAsync<PasswordlessEmailResponse>("passwordless/start", ContentTypes.Json,
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
            return Connection.PostAsync<PasswordlessSmsResponse>("passwordless/start", ContentTypes.Json,
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
            return Connection.PostAsync<AuthenticationResponse>("oauth/ro", ContentTypes.Json,
                request, null, null, null, null, null);

            //return Connection.PostAsync<AuthenticationResponse>("oauth/ro", ContentTypes.Json,
            //    null, null, null, null, null, new Dictionary<string, string>
            //    {
            //        { "client_id", request.ClientId },
            //        { "username", request.Username },
            //        { "password", request.Password },
            //        { "id_token", request.IdToken },
            //        { "connection", request.Connection },
            //        { "grant_type", request.GrantType },
            //        { "scope", request.Scope },
            //        { "device", request.Device }
            //    });
        }
    }
}