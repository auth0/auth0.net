using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationInvitation
    {

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }
        [JsonProperty("inviter")]
        public OrganizationInvitationInviter Inviter { get; set; }

        [JsonProperty("invitee")]
        public OrganizationInvitationInvitee Invitee { get; set; }

        [JsonProperty("invitation_url")]
        public string InvitationUrl { get; set; }


        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }


        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("app_metadata")]
        public dynamic AppMetadata { get; set; }

        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }

        [JsonProperty("ticket_id")]
        public string TicketId { get; set; }

        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
    }
}