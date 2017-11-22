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
        /// The user ID for which the ticket is to be created.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The ticket's lifetime in seconds starting from the moment of creation. 
        /// After expiration the ticket can not be used to verify the users's email. 
        /// If not specified or if you send 0 the Auth0 default lifetime will be applied
        /// </summary>
        [JsonProperty("ttl_sec")]
        public int ExpiresIn { get; set; }
    }

}