using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationDeleteMembersRequest
    {
        /// <summary>
        /// List of user IDs to remove from the organization as members.
        /// </summary>
        [JsonProperty("members")]
        public IList<string> Members { get; set; }
    }
}
