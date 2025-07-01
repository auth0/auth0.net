using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Attribute Validation
/// </summary>
public class ConnectionOptionsAttributeValidation
{
    /// <summary>
    /// Minimum allowed length
    /// </summary>
    [JsonProperty("min_length")]
    public int MinLength { get; set; }
        
    /// <summary>
    /// Maximum allowed length
    /// </summary>
    [JsonProperty("max_length")]
    public int MaxLength { get; set; }
        
    [JsonProperty("allowed_types")]
    public ConnectionOptionsAttributeAllowedTypes AllowedTypes { get; set; }
}

public class ConnectionOptionsAttributeAllowedTypes
{
    [JsonProperty("email")]
    public bool? Email { get; set; }
        
    [JsonProperty("phone_number")]
    public bool? PhoneNumber { get; set; }
}