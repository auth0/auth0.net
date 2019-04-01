using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Contains details of permissions that should be assigned to a role.
    /// </summary>
    public class AssociatePermissionsRequest
    {
        /// <summary>
        /// User IDs to assign to the role.
        /// </summary>
        [JsonProperty("permissions")]
        public IList<PermissionIdentity> Permissions { get; set; }
    }
}
