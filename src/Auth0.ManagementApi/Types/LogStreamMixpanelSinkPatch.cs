using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record LogStreamMixpanelSinkPatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("mixpanelRegion")]
    public required LogStreamMixpanelRegionEnum MixpanelRegion { get; set; }

    /// <summary>
    /// Mixpanel Project Id
    /// </summary>
    [JsonPropertyName("mixpanelProjectId")]
    public required string MixpanelProjectId { get; set; }

    /// <summary>
    /// Mixpanel Service Account Username
    /// </summary>
    [JsonPropertyName("mixpanelServiceAccountUsername")]
    public required string MixpanelServiceAccountUsername { get; set; }

    /// <summary>
    /// Mixpanel Service Account Password
    /// </summary>
    [Optional]
    [JsonPropertyName("mixpanelServiceAccountPassword")]
    public string? MixpanelServiceAccountPassword { get; set; }

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
