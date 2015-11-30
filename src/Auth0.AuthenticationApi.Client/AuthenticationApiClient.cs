using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;

namespace Auth0.AuthenticationApi.Client
{
    public class AuthenticationApiClient : IAuthenticationApiClient
    {
        public AuthenticationApiClient()
        {
            
        }
        public Task<Uri> BuildAuthorizationUri(BuildAuthorizationUriRequest request)
        {
            throw new NotImplementedException();
        }
    }
}