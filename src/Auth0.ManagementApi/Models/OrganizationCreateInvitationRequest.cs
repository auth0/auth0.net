using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Requests structure for creating a new organization invitation.
    /// </summary>
    public class OrganizationCreateInvitationRequest
    {
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
        /// The id of the connection to force invitee to authenticate with.
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
        /// Number of seconds for which the invitation is valid before expiration.
        /// </summary>
        /// <remarks>
        /// If unspecified or set to 0, this value defaults to 604800 seconds (7 days). Max value: 2592000 seconds (30 days).
        /// </remarks>
        [JsonProperty("ttl_sec")]
        public int? TimeToLive { get; set; }

        /// <summary>
        /// Whether the user will receive an invitation email (true) or no email (false), true by default
        /// </summary>
        [JsonProperty("send_invitation_email")]
        public bool? SendInvitationEmail { get; set; }

        /// <summary>
        /// List of role IDs to associated with the user.
        /// </summary>
        [JsonProperty("roles")]
        public IList<string> Roles { get; set; }
    }
}