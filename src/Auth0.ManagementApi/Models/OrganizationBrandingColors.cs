using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationBrandingColors
    {
        [JsonProperty("primary")]
        public string Primary { get; set; }
        [JsonProperty("page_background")]
        public IList<string> PageBackground { get; set; }
    }
}
