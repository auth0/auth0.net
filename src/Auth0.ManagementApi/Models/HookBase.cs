using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Base class for hooks.
    /// </summary>
    public abstract class HookBase
    {
        /// <summary>
        /// Gets or sets the name of the hook.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets whether the hook is enabled.
        /// </summary>
        /// <remarks>
        /// True if the connection is enabled, false otherwise.
        /// </remarks>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the code to be executed when the hook runs.
        /// </summary>
        [JsonProperty("script")]
        public string Script { get; set; }

        /// <summary>
        /// Gets or sets the triggerId of the hook. 
        /// </summary>
        [JsonProperty("triggerId")]
        public string TriggerId { get; set; }
    }
}