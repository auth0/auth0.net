using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateFlowsVaultConnectionResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Flows Vault Connection identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// Flows Vault Connection app identifier.
    /// </summary>
    [JsonPropertyName("app_id")]
    public required string AppId { get; set; }

    /// <summary>
    /// Flows Vault Connection environment.
    /// </summary>
    [Optional]
    [JsonPropertyName("environment")]
    public string? Environment { get; set; }

    /// <summary>
    /// Flows Vault Connection name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Flows Vault Connection custom account name.
    /// </summary>
    [Optional]
    [JsonPropertyName("account_name")]
    public string? AccountName { get; set; }

    /// <summary>
    /// Whether the Flows Vault Connection is configured.
    /// </summary>
    [JsonPropertyName("ready")]
    public required bool Ready { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date when this Flows Vault Connection was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date when this Flows Vault Connection was updated.
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date when this Flows Vault Connection was refreshed.
    /// </summary>
    [Optional]
    [JsonPropertyName("refreshed_at")]
    public DateTime? RefreshedAt { get; set; }

    [JsonPropertyName("fingerprint")]
    public required string Fingerprint { get; set; }

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
