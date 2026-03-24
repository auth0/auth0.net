using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateDirectoryProvisioningResponseContent : IJsonOnDeserialized
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
    /// The mapping between Auth0 and IDP user attributes
    /// </summary>
    [JsonPropertyName("mapping")]
    public IEnumerable<DirectoryProvisioningMappingItem> Mapping { get; set; } =
        new List<DirectoryProvisioningMappingItem>();

    /// <summary>
    /// Whether periodic automatic synchronization is enabled
    /// </summary>
    [JsonPropertyName("synchronize_automatically")]
    public required bool SynchronizeAutomatically { get; set; }

    [Optional]
    [JsonPropertyName("synchronize_groups")]
    public string? SynchronizeGroups { get; set; }

    /// <summary>
    /// The timestamp at which the directory provisioning configuration was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The timestamp at which the directory provisioning configuration was last updated
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The timestamp at which the connection was last synchronized
    /// </summary>
    [Optional]
    [JsonPropertyName("last_synchronization_at")]
    public DateTime? LastSynchronizationAt { get; set; }

    /// <summary>
    /// The status of the last synchronization
    /// </summary>
    [Optional]
    [JsonPropertyName("last_synchronization_status")]
    public string? LastSynchronizationStatus { get; set; }

    /// <summary>
    /// The error message of the last synchronization, if any
    /// </summary>
    [Optional]
    [JsonPropertyName("last_synchronization_error")]
    public string? LastSynchronizationError { get; set; }

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
