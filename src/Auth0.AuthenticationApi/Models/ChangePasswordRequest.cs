using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to change a password via an email.
    /// </summary>
    public class ChangePasswordRequest : UserMaintenanceRequestBase
    {
        /// <summary>
        /// The organization_id of the Organization associated with the user.
        /// </summary>
        [JsonProperty("organization")]
        public string Organization { get; set; }
    }
}