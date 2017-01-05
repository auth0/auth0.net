using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class ScopeEntry
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("actions")]
        public string[] Actions { get; set; }
    }
}