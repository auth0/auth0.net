using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Password policy options for flexible password policy configuration
/// </summary>
[Serializable]
public record ConnectionPasswordOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("complexity")]
    public ConnectionPasswordOptionsComplexity? Complexity { get; set; }

    [Optional]
    [JsonPropertyName("dictionary")]
    public ConnectionPasswordOptionsDictionary? Dictionary { get; set; }

    [Optional]
    [JsonPropertyName("history")]
    public ConnectionPasswordOptionsHistory? History { get; set; }

    [Optional]
    [JsonPropertyName("profile_data")]
    public ConnectionPasswordOptionsProfileData? ProfileData { get; set; }

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
