using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    public class ActionSecret
    {
        /// <summary>
        /// The name of the particular secret, e.g. API_KEY.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The time when the secret was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// The value of the particular secret, e.g. secret123. A secret's value can only be set upon creation. A secret's value will never be returned by the API.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}