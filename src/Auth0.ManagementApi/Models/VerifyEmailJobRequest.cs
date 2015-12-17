using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class VerifyEmailJobRequest
    {

        /// <summary>
        /// The identifier of the user to whom the email will be sent.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

    }

}