using System;
using Auth0.Core;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class DeviceCredentialCreateRequest : DeviceCredentialBase
    {

        /// <summary>
        /// Gets or sets the ID of the client for which the credential will be created.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the value of the credentia
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

    }

}