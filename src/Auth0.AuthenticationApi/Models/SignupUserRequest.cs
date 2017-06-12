using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to sign up a new user.
    /// </summary>
    public class SignupUserRequest : UserMaintenanceRequestBase
    {
        /// <summary>
        /// Contains user meta data. The user has read/write access to this.
        /// </summary>
        [JsonProperty("user_metadata")]
        public dynamic UserMetadata { get; set; }
    }
}