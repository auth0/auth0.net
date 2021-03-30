using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationAddMemberRolesRequest
    {
        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
    }
}
