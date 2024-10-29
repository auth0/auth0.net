using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    public class ActionRequiredBase
    {
        /// <summary>
        /// Possible values: [UNSPECIFIED, STRING]
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
        
        /// <summary>
        /// Name of the parameter
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Flag for if this parameter is required
        /// </summary>
        [JsonProperty("required")]
        public bool? Required { get; set; }
        
        /// <summary>
        /// The temp flag for if this parameter is required(experimental; for Labs use only)
        /// </summary>
        [JsonProperty("optional")]
        public bool? Optional { get; set; }
        
        /// <summary>
        /// Short label for this parameter
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }
        
        /// <summary>
        /// Lengthier description for this parameter
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
        
        /// <summary>
        /// Default value for this parameter
        /// </summary>
        [JsonProperty("default_value")]
        public string DefaultValue { get; set; }
        
        /// <summary>
        /// Placeholder text for this parameter
        /// </summary>
        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }
        
        /// <inheritdoc cref="Auth0.ManagementApi.Models.Actions.ActionOption"/>
        [JsonProperty("options")]
        public IList<ActionOption> Options { get; set; }
    }
}