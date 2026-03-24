using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateScimConfigurationResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The connection's identifier
    /// </summary>
    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    /// <summary>
    /// The connection's name
    /// </summary>
    [JsonPropertyName("connection_name")]
    public required string ConnectionName { get; set; }

    /// <summary>
    /// The connection's strategy
    /// </summary>
    [JsonPropertyName("strategy")]
    public required string Strategy { get; set; }

    /// <summary>
    /// The tenant's name
    /// </summary>
    [JsonPropertyName("tenant_name")]
    public required string TenantName { get; set; }

    /// <summary>
    /// User ID attribute for generating unique user ids
    /// </summary>
    [JsonPropertyName("user_id_attribute")]
    public required string UserIdAttribute { get; set; }

    /// <summary>
    /// The mapping between auth0 and SCIM
    /// </summary>
    [JsonPropertyName("mapping")]
    public IEnumerable<ScimMappingItem> Mapping { get; set; } = new List<ScimMappingItem>();

    /// <summary>
    /// The ISO 8601 date and time the SCIM configuration was created at
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 date and time the SCIM configuration was last updated on
    /// </summary>
    [JsonPropertyName("updated_on")]
    public required DateTime UpdatedOn { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
