using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections
{
    /// <summary>
    /// Password strength level
    /// </summary>
    public enum ConnectionOptionsPasswordPolicy
    {
        [EnumMember(Value = "none")]
        None,
        
        [EnumMember(Value = "low")]
        Low,
        
        [EnumMember(Value = "fair")]
        Fair,
        
        [EnumMember(Value = "good")]
        Good,
        
        [EnumMember(Value = "excellent")]
        Excellent
    }

    /// <summary>
    /// Password complexity options
    /// </summary>
    public class ConnectionOptionsPasswordComplexityOptions
    {
        /// <summary>
        /// Minimum password length
        /// </summary>
        [JsonProperty("min_length")]
        public int MinLength { get; set; }
    }

    /// <summary>
    /// Options for password history policy
    /// </summary>
    public class ConnectionOptionsPasswordHistory
    {
        [JsonProperty("enable")]
        public bool? Enable { get; set; }
        
        [JsonProperty("size")]
        public int Size { get; set; }
    }

    /// <summary>
    /// Options for personal info in passwords policy
    /// </summary>
    public class ConnectionOptionsPasswordNoPersonalInfo
    {
        [JsonProperty("enable")]
        public bool? Enable { get; set; }
    }

    /// <summary>
    /// Options for password dictionary policy
    /// </summary>
    public class ConnectionOptionsPasswordDictionary
    {
        [JsonProperty("enable")]
        public bool? Enable { get; set; }
        
        /// <summary>
        /// Custom Password Dictionary. An array of up to 200 entries.
        /// </summary>
        [JsonProperty("dictionary")]
        public string[] Dictionary { get; set; }
    }
}