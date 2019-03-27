using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    ///
    /// </summary>
    public class AssignUsersRequest
    {
        /// <summary>
        /// User IDs to assign to the role
        /// </summary>
        [JsonProperty("users")]
        public string[] Users { get; set; }
    }
}
