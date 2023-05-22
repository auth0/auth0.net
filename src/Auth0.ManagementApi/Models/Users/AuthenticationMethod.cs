using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Users
{
    public class AuthenticationMethod : AuthenticationMethodBase
    {
        /// <summary>
        /// The authentication method status
        /// </summary>
        [JsonProperty("confirmed")]
        public bool? Confirmed { get; set; }

        /// <summary>
        /// A human-readable label to identify the authentication method
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The ID of a linked authentication method. Linked authentication methods will be deleted together.
        /// </summary>
        [JsonProperty("link_id")]
        public string LinkId { get; set; }

        /// <summary>
        /// Applies to phone authentication methods only. The destination phone number used to send verification codes via text and voice.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Applies to email and email-verification authentication methods only. The email address used to send verification messages.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Applies to webauthn authentication methods only. The ID of the generated credential.
        /// </summary>
        [JsonProperty("key_id")]
        public string KeyId { get; set; }

        /// <summary>
        /// Applies to webauthn authentication methods only. The public key.
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Authenticator creation date
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Enrollment date
        /// </summary>
        [JsonProperty("enrolled_at")]
        public DateTime? EnrolledAt { get; set; }

        /// <summary>
        /// Last authentication
        /// </summary>
        [JsonProperty("last_auth_at")]
        public DateTime? LastAuthAt { get; set; }

        /// <summary>
        /// The authentication method preferred for phone authenticators.
        /// </summary>
        [JsonProperty("preferred_authentication_method")]
        public string PreferredAuthenticationMethod { get; set; } = null;

        [JsonProperty("authentication_methods")]
        public IList<AuthenticationMethodBase> AuthenticationMethods { get; set; }
    }
}

