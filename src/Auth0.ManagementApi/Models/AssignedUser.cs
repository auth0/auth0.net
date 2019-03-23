using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class AssignedUser
    {
        /// <summary>
        /// A unique identifier of the user per identity provider, same for all apps (e.g.: google-oauth2|103547991597142817347).
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// URL pointing to the user picture (if not available, will use gravatar.com with the email).
        /// </summary>
        [JsonProperty("picture")]
        public string Picture { get; set; }

        /// <summary>
        /// The full name of the user (e.g.: John Foo).
        /// </summary>
        [JsonProperty("name")]
        public string FullName { get; set; }

        /// <summary>
        /// The user's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
