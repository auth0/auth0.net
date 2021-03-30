using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationDeleteMembersRequest
    {
        [JsonProperty("members")]
        public IList<string> Members { get; set; }
    }
}
