using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.Core
{
    /// <summary>
    /// Base class for Client Grants
    /// </summary>
    public class ClientGrantBase
    {
        /// <summary>
        /// Gets or sets the audience
        /// </summary>
        [JsonProperty("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the <see cref="Auth0.Core.Client"/>
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the list of scopes
        /// </summary>
        [JsonProperty("scope")]
        public List<string> Scope { get; set; }
    }
}