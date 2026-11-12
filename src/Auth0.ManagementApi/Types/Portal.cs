using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record Portal : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Optional]
    [JsonPropertyName("navigation")]
    public PortalNavigation? Navigation { get; set; }

    [Optional]
    [JsonPropertyName("pages")]
    public PortalPagesByType? Pages { get; set; }

    [JsonPropertyName("slug")]
    public required string Slug { get; set; }

    [Optional]
    [JsonPropertyName("client")]
    public PortalClientSecretPost? Client { get; set; }

    [Optional]
    [JsonPropertyName("custom_code")]
    public PortalCustomCode? CustomCode { get; set; }

    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

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
