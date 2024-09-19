using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationInvitation
    {
        /// <summary>
        /// The ID of the invitation
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the organization for which the user should be invited
        /// </summary>
        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        /// <summary>
        /// Information about the person that is creating the invitation
        /// </summary>
        [JsonProperty("inviter")]
        public OrganizationInvitationInviter Inviter { get; set; }

        /// <summary>
        /// Information about the person being invited
        /// </summary>
        [JsonProperty("invitee")]
        public OrganizationInvitationInvitee Invitee { get; set; }

        /// <summary>
        /// The invitation URL to be sent to the invitee.
        /// </summary>
        [JsonProperty("invitation_url")]
        public string InvitationUrl { get; set; }

        /// <summary>
        /// The creation time of the invitation.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The expiration time of the invitation.
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// The ID of the connection to force invitee to authenticate with.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Auth0 client ID. Used to resolve the application's login initiation endpoint.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Contains app metadata. The user has read/write access to this.
        /// </summary>
        [JsonProperty("app_metadata")]
        public dynamic AppMetadata { get; set; }

        /// <summary>
        /// Contains user metadata. The user has read/write access to this.
        /// </summary>
        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }

        /// <summary>
        /// The ID of the invitation ticket.
        /// </summary>
        [JsonProperty("ticket_id")]
        public string TicketId { get; set; }

        /// <summary>
        /// List of role IDs to associated with the user.
        /// </summary>
        [JsonProperty("roles")]
        public IList<string> Roles { get; set; } 
    }
}