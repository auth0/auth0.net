using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Keys;

/// <summary>
/// Contains information required for creating an encryption key.
/// </summary>
public class EncryptionKeyCreateRequest
{
    /// <summary>
    /// Type of the encryption key to be created.
    /// Possible values: [customer-provided-root-key, tenant-encryption-key]
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }
}