using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions
{
    /// <summary>
    /// Request configuration for deleting an action.
    /// </summary>
    public class DeleteActionRequest
    {
        /// <summary>
        /// Force action deletion detaching bindings
        /// </summary>
        [JsonProperty("force")]
        public bool? Force { get; set; }
    }
}