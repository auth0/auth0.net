using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Sessions
{
    public class Sessions : SessionsBase
    {
        /// <summary>
        /// The date and time when the session was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        
        /// <summary>
        /// The date and time when the session was last authenticated
        /// </summary>
        [JsonProperty("authenticated_at")]
        public DateTime? AuthenticatedAt { get; set; }
        
        /// <summary>
        /// The date and time last successful user interaction with the session
        /// </summary>
        [JsonProperty("last_interacted_at")]
        public DateTime? LastInteractedAt { get; set; }
        
        /// <inheritdoc cref="Auth0.ManagementApi.Models.Sessions.ClientDetails"/>
        [JsonProperty("clients")]
        public IList<ClientDetails> Clients { get; set; }
        
        /// <summary>
        /// Details about authentication signals obtained during the login flow
        /// </summary>
        [JsonProperty("authentication")]
        public Authentication Authentication { get; set; }
    }
}