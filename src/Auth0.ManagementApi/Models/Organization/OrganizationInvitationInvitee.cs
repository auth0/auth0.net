using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class OrganizationInvitationInvitee
    {
        /// <summary>
        /// The email for the user that is to be invited.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}