using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{

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