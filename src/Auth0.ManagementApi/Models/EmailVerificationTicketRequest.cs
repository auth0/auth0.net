using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class EmailVerificationTicketRequest
    {
        /// <summary>
        /// The user will be redirected to this endpoint once the ticket is used.
        /// </summary>
        [JsonProperty("result_url")]
        public string ResultUrl { get; set; }

        /// <summary>
        /// The ticket's lifetime in seconds starting from the moment of creation. 
        /// After expiration the ticket can not be used to verify the users's email. 
        /// If not specified or if you send 0 the Auth0 default lifetime will be applied
        /// </summary>
        [JsonProperty("ttl_sec")]
        public int Ttl { get; set; }

        /// <summary>
        /// The user ID for which the ticket is to be created.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Sets the identity. Needed to verify primary identities when using social, enterprise, or passwordless connections.
        /// It is also required to verify secondary identities.
        /// </summary>
        [JsonProperty("identity")]
        public EmailVerificationIdentity Identity { get; set; }

        /// <summary>
        /// The organization ID.
        /// </summary>
        /// <summary>
        /// If provided the organization_id and organization_name will be included in the redirection URL querystring
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
    }

}