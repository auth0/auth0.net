using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Custom color settings.
/// </summary>
[Serializable]
public record UpdateBrandingColors : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Accent color.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("primary")]
    public Optional<string?> Primary { get; set; }

    [Optional]
    [JsonPropertyName("page_background")]
    public UpdateBrandingPageBackground? PageBackground { get; set; }

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
