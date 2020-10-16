using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class UsersExportsJobField
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("export_as")]
        public string ExportAs { get; set; }
    }
}
