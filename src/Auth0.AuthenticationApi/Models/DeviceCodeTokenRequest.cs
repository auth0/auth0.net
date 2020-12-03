namespace Auth0.AuthenticationApi.Models
{
    public class DeviceCodeTokenRequest
    {
        /// <summary>
        /// Device code to be exchanged.
        /// </summary>
        public string DeviceCode { get; set; }

        /// <summary>
        /// Client ID of the application.
        /// </summary>
        public string ClientId { get; set; }
    }
}