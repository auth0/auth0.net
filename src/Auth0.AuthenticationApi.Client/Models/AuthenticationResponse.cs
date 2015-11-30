namespace Auth0.AuthenticationApi.Client.Models
{
    public class AuthenticationResponse
    {
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
    }
}