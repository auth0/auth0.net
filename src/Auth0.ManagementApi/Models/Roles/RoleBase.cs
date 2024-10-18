using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for roles.
    /// </summary>
    public abstract class RoleBase
    {
        /// <summary>
        /// Gets or sets the name of the role.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the role. Max character count is 140
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
