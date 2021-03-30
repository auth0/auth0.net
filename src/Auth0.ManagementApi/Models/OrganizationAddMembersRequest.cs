using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{

    public class OrganizationAddMembersRequest
    {
        [JsonProperty("members")]
        public IList<string> Members { get; set; }
    }
}
