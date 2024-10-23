using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    
    /// <summary>
    /// JWT-secured Authorization Requests (JAR) settings.
    /// </summary>
    public class SignedRequestObject
    {
        /// <summary>
        /// Indicates whether the JAR requests are mandatory
        /// </summary>
        [JsonProperty("required")]
        public bool? Required { get; set; }
        
        /// <summary>
        /// List of <see cref="Credentials"/> for the JAR requests
        /// </summary>
        [JsonProperty("credentials")]
        public IList<Credentials> Credentials { get; set; }
    }
}