using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Phone provider configuration schema
/// </summary>
[Serializable]
public record PhoneProviderSchemaMasked : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the tenant
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant")]
    public string? Tenant { get; set; }

    [JsonPropertyName("name")]
    public required PhoneProviderNameEnum Name { get; set; }

    [Optional]
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    /// <summary>
    /// Whether the provider is enabled (false) or disabled (true).
    /// </summary>
    [Optional]
    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [Optional]
    [JsonPropertyName("configuration")]
    public PhoneProviderConfiguration? Configuration { get; set; }

    /// <summary>
    /// The provider's creation date and time in ISO 8601 format
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The date and time of the last update to the provider in ISO 8601 format
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
