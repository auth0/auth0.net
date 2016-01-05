namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to impersonate a user.
    /// </summary>
    public class ImpersonationRequest
    {
        /// <summary>
        /// The client ID of the application
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The ID of the user who is impersonated.
        /// </summary>
        public string ImpersonateId { get; set; }

        /// <summary>
        /// The ID of the user doing the impersonation.
        /// </summary>
        public string ImpersonatorId { get; set; }

        /// <summary>
        /// The protocol to use. Can be one of oauth2, wsfed, wsfed-rms, samlp
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// The response type
        /// </summary>
        public string ResponseType { get; set; }

        /// <summary>
        /// The state parameter to pass
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The bearer token to pass along with the request in the Authorization header.
        /// </summary>
        public string Token { get; set; }
    }
}