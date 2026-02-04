using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateScimConfigurationResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The connection's identifier
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    /// <summary>
    /// The connection's identifier
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_name")]
    public string? ConnectionName { get; set; }

    /// <summary>
    /// The connection's strategy
    /// </summary>
    [Optional]
    [JsonPropertyName("strategy")]
    public string? Strategy { get; set; }

    /// <summary>
    /// The tenant's name
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant_name")]
    public string? TenantName { get; set; }

    /// <summary>
    /// User ID attribute for generating unique user ids
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id_attribute")]
    public string? UserIdAttribute { get; set; }

    /// <summary>
    /// The mapping between auth0 and SCIM
    /// </summary>
    [Optional]
    [JsonPropertyName("mapping")]
    public IEnumerable<ScimMappingItem>? Mapping { get; set; }

    /// <summary>
    /// The Date Time Scim Configuration was created
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// The Date Time Scim Configuration was last updated
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_on")]
    public string? UpdatedOn { get; set; }

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
