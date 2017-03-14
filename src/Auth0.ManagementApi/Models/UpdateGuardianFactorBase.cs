using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class UpdateGuardianFactorBase
    {
        /// <summary>
        /// States if this factor is enabled
        /// </summary>
        [JsonProperty("enabled")]
        public bool IsEnabled { get; set; }
    }
}