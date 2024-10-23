using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Sessions
{
    public class Authentication
    {
        /// <summary>
        /// Contains the authentication methods a user has completed during their session
        /// </summary>
        [JsonProperty("methods")]
        public IList<AuthenticationMethods> Methods { get; set; }
    }
}