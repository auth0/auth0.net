using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a Generate Recovery Code response.
    /// </summary>
    public class GenerateRecoveryCodeResponse
    {
        /// <summary>
        /// New recovery code.
        /// </summary>
        [JsonProperty("recovery_code")]
        public string RecoveryCode { get; set; }
    }
}