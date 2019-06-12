using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Tenant flags.
    /// </summary>
    public class TenantFlags
    {
        /// <summary>
        /// Enables the first version of the Change Password flow. We've deprecated this option and recommending a safer flow. This flag is only for backwards compatibility.
        /// </summary>
        [JsonProperty("change_pwd_flow_v1")]
        public bool ChangePwdFlowV1 { get; set; }

        /// <summary>
        /// This flag enables the APIs section.
        /// </summary>
        [JsonProperty("enable_apis_section")]
        public bool EnableAPIsSection { get; set; }

        /// <summary>
        /// If set to true all Impersonation functionality is disabled for the Tenant. This is a read-only attribute.
        /// </summary>
        [JsonProperty("disable_impersonation")]
        public bool DisableInterpretation { get; set; }

        /// <summary>
        /// This flag determines whether all current connections shall be enabled when a new client is created. Default value is true.
        /// </summary>
        [JsonProperty("enable_client_connections")]
        public bool EnableClientConnections { get; set; }

        /// <summary>
        /// This flag enables advanced API Authorization scenarios.
        /// </summary>
        [JsonProperty("enable_pipeline2")]
        public bool EnablePipeline2 { get; set; }

        /// <summary>
        /// If true, the classic Universal Login prompts will not include additional security headers to prevent click-jacking.
        /// </summary>
        [JsonProperty("disable_clickjack_protection_headers")]
        public bool DisableClickjackProtectionHeaders { get; set; }
    }
}
