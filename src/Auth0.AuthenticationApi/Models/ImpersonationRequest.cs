namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to obtain a one-time link for impersonating a user.
    /// </summary>
    /// <remarks>This feature has been deprecated and will be removed from Auth0 and this library in a future release.</remarks>
    public class ImpersonationRequest
    {
        /// <summary>
        /// The client_id of the client (application) that is generating the impersonation link.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// ID of the user who is to be impersonated.
        /// </summary>
        public string ImpersonateId { get; set; }

        /// <summary>
        /// user_id of the impersonator.
        /// </summary>
        public string ImpersonatorId { get; set; }

        /// <summary>
        /// Protocol to use against the identity provider. Can be one of oauth2, wsfed, wsfed-rms, samlp.
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// Response type - should be "code".
        /// </summary>
        public string ResponseType { get; set; }

        /// <summary>
        /// State parameter to pass.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Bearer token to include with the request in the Authorization header.
        /// </summary>
        public string Token { get; set; }
    }
}