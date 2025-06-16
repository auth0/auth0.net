using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Contains details for sending an email address verification link.
    /// </summary>
    public class VerifyEmailJobRequest
    {
        /// <summary>
        /// The identifier of the user to whom the email will be sent.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The id of the client, if not provided the global one will be used
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// The primary identity to verify when using social, enterprise, or passwordless connections.
        /// It is also required to verify secondary identities.
        /// </summary>
        [JsonProperty("identity")]
        public EmailVerificationIdentity Identity { get; set; }

        /// <summary>
        /// ID of the organization.
        /// </summary>
        /// <remarks>
        /// If provided, the organization_id and organization_name will be included as query arguments in the link back to the application.
        /// </remarks>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
    }
}