using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Users
{
    public class AuthenticationMethodCreateRequest
    {
        /// <summary>
        /// The type of the authentication method
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// A human-readable label to identify the authentication method.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Base32 encoded secret for TOTP generation.
        /// </summary>
        [JsonProperty("totp_secret")]
        public string TOTPSecret { get; set; }

        /// <summary>
        /// Applies to phone authentication methods only. The destination phone number used to send verification codes via text and voice.
        /// </summary>
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Applies to email authentication methods only. The email address used to send verification messages.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Preferred phone authentication method.
        /// </summary>
        [JsonProperty("preferred_authentication_method")]
        public string PreferredAuthenticationMethod { get; set; }

        /// <summary>
        /// Applies to email webauthn authenticators only. The id of the credential.
        /// </summary>
        [JsonProperty("key_id")]
        public string KeyId { get; set; }

        /// <summary>
        /// Applies to email webauthn authenticators only. The public key.
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; }

        /// <summary>
        /// Applies to email webauthn authenticators only. The relying party identifier.
        /// </summary>
        [JsonProperty("relying_party_indentifier")]
        public string RelyingPartyIdentifier { get; set; }
	}
}

