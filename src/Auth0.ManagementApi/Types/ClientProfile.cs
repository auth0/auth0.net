using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ClientProfile : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    [JsonPropertyName("client_configuration")]
    public required ClientProfileClientConfiguration ClientConfiguration { get; set; }

    [JsonPropertyName("apply_policy")]
    public required ClientProfileApplyPolicy ApplyPolicy { get; set; }

    /// <summary>
    /// Timestamp of creation.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Timestamp of last update.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

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
