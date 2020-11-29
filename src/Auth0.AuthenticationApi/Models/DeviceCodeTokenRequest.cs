namespace Auth0.AuthenticationApi.Models
{
    public class DeviceCodeTokenRequest
    {
        public string DeviceCode { get; set; }

        public string ClientId { get; set; }
    }
}