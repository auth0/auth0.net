using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationDeleteMemberRolesRequest
    {
        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
    }
}
