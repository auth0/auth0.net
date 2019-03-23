using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    ///
    /// </summary>
    public class AssignRolesRequest
    {
        /// <summary>
        /// Role IDs to assign to the user
        /// </summary>
        [JsonProperty("roles")]
        public string[] Roles { get; set; }
    }
}