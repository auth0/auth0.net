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
            //RestRequest restRequest = new RestRequest("authorize");
            //restRequest.AddQueryString("response_type", request.ResponseType);
            //restRequest.AddQueryString("client_id", request.ClientId);
            //// etc.

            //// And then
            //return restRequest.GetResourceUri(baseUri);

            throw new NotImplementedException();
        }

        public Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            return Connection.PostAsync<AuthenticationResponse>("auth/ro", ContentTypes.Json,
                null, null, null, null, null, new Dictionary<string, string>
                {
                    { "client_id", request.ClientId },
                    { "username", request.Username },
                    { "password", request.Password },
                    { "id_token", request.IdToken },
                    { "connection", request.Connection },
                    { "grant_type", request.GrantType },
                    { "scope", request.Scope },
                    { "device", request.Device }
                });
        }
    }
}