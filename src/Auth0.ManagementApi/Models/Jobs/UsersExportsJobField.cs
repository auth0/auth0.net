using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Contains details of a field to be included in the users exports job
    /// </summary>
    public class UsersExportsJobField
    {
        /// <summary>
        /// Name of the field in the profile.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Export the field using a different name as the one defined in the profile.
        /// </summary>
        [JsonProperty("export_as")]
        public string ExportAs { get; set; }
    }
}
