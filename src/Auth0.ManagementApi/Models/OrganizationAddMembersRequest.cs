using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationAddMembersRequest
    {
        /// <summary>
        /// List of user IDs to add to the organization as members.
        /// </summary>
        [JsonProperty("members")]
        public IList<string> Members { get; set; }
    }
}
