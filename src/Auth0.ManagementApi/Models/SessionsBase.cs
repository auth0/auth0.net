using System;
using Auth0.ManagementApi.Models.RefreshTokens;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class SessionsBase
    {
        /// <summary>
        /// The ID of the refresh token
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// ID of the user which can be used when interacting with other APIs.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        
        /// <summary>
        /// The date and time when the refresh token was created
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// The date and time when the refresh token will expire if idle
        /// </summary>
        [JsonProperty("idle_expires_at")]
        public DateTime? IdleExpiresAt { get; set; }
        
        /// <summary>
        /// The date and time when the refresh token will expire
        /// </summary>
        [JsonProperty("expires_at")]
        public DateTime? ExpiresAt { get; set; }
        
        /// <inheritdoc cref="Auth0.ManagementApi.Models.RefreshTokens.Device" />
        [JsonProperty("device")]
        public Device Device { get; set; }
    }
}