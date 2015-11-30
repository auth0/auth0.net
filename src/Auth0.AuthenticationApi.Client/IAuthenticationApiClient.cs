using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi.Client.Models;

namespace Auth0.AuthenticationApi.Client
{
    public interface IAuthenticationApiClient
    {
        Task<Uri> BuildAuthorizationUri(BuildAuthorizationUriRequest request);
    }
}