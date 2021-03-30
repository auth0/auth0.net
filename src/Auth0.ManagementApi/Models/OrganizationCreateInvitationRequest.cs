using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationGetAllRequest : OrganizationGetRequest
    {
        /// <summary>
        /// Field to sort by. Use field:order where order is 1 for ascending and -1 for descending Defaults to created_at:-1.
        /// </summary>
        public string Sort { get; set; } = null;

    }

    public class OrganizationGetRequest
    {
        /// <summary>
        /// A comma separated list of fields to include or exclude (depending on <see cref="IncludeFields"/>) from the result, empty to retrieve all fields.
        /// </summary>
        public string Fields { get; set; } = null;

        /// <summary>
        /// Specifies whether the fields specified in <see cref="Fields"/> should be included or excluded in the result.
        /// </summary>
        public bool? IncludeFields { get; set; } = null;

    }

    /// <summary>
    /// Requests structure for creating a new organization invitation.
    /// </summary>
    public class OrganizationCreateInvitationRequest
    {
        [JsonProperty("inviter")]
        public OrganizationInvitationInviter Inviter { get; set; }

        [JsonProperty("invitee")]
        public OrganizationInvitationInvitee Invitee { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("app_metadata")]
        public dynamic AppMetadata { get; set; }

        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }

        [JsonProperty("ttl_sec")]
        public int TimeToLive { get; set; }

        [JsonProperty("send_invitation_email")]
        public bool SendInvitationEmail { get; set; }

        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
    }
}