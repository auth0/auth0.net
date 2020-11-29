namespace Auth0.AuthenticationApi.Models
{
    public class DeviceFlowRequest
    {
        public string ClientId { get; set; }

        public string Scope { get; set; }

        public string Audience { get; set; }
    }
}