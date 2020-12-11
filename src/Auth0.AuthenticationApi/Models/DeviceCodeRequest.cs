namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to start a Device Authorization flow.
    /// </summary>
    public class DeviceCodeRequest
    {
        /// <summary>
        /// Client ID of the application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Optional scopes to be requested. Separate multiple values with a space.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Optional unique identifier of the target API to access.
        /// </summary>
        public string Audience { get; set; }
    }
}