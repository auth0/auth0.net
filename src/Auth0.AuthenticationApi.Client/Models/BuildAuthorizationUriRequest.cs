using System;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class BuildAuthorizationUriRequest
    {
        public string ClientId { get; set; }
        public string Connection { get; set; }
        public Uri RedirectUri { get; set; }
        public AuthorizationResponseType ResponseType { get; set; }
        public string Scope { get; set; }
        public string State { get; set; }
    }
}