using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Class for roles.
    /// </summary>
    public class Role : RoleBase
    {
        /// <summary>
        /// Gets or sets the id of the role.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}