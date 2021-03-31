using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class Organization : OrganizationBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
