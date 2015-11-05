using System;
using Newtonsoft.Json;

namespace Auth0.Core.Models
{
    public class User : UserBase
    {
        /// <summary>
        /// Gets or sets whether the user's phone number is verified.
        /// </summary>
        /// <remarks>
        /// True if the phone is verified, otherwise false.
        /// 
        /// This is only valid for users from SMS connections.
        /// </remarks>
        [JsonProperty("phone_verified")]
        public bool PhoneVerified { get; set; }

        /// <summary>
        /// Gets or sets the user's unique identifier.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the date the user was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date the user was last updated (modified).
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// An array of objects with information about the user's identities. More than one will exists in case accounts are linked
        /// </summary>
        [JsonProperty("identities")]
        public Identity[] Identities { get; set; }
    }
}