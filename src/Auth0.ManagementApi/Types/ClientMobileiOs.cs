using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// iOS native app configuration.
/// </summary>
[Serializable]
public record ClientMobileiOs : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Identifier assigned to the Apple account that signs and uploads the app to the store.
    /// </summary>
    [Optional]
    [JsonPropertyName("team_id")]
    public string? TeamId { get; set; }

    /// <summary>
    /// Assigned by developer to the app as its unique identifier inside the store. Usually this is a reverse domain plus the app name, e.g. `com.you.MyApp`.
    /// </summary>
    [Optional]
    [JsonPropertyName("app_bundle_identifier")]
    public string? AppBundleIdentifier { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
