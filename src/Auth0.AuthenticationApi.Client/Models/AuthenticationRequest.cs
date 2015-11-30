using System;

namespace Auth0.AuthenticationApi.Client.Models
{
    public class AuthenticationRequest
    {
        public string ClientId { get; set; }
        public string Connection { get; set; }
        public string Device { get; set; }
        public string GrantType { get; set; }
        public string IdToken { get; set; }
        public string Password { get; set; }
        public string Scope { get; set; }
        public string Username { get; set; }
    }
}