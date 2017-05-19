using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth0.ManagementApi.Models
{
    public class ClientResourceServerAssociation
    {
        /// <summary>
        /// The resource server identifier.
        /// </summary>
        [JsonProperty("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// The scopes to request from the user to access the resource server.
        /// </summary>
        [JsonProperty("scopes")]
        public string[] Scopes { get; set; }

    }
}
