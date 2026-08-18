using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The Cross App Access resource app status configuration.
/// </summary>
[Serializable]
public record ConnectionProfileCrossAppAccessResourceAppStatus : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("default_value")]
    public required ConnectionProfileCrossAppAccessResourceAppStatusDefaultValueEnum DefaultValue { get; set; }

    [Optional]
    [JsonPropertyName("allowed_values")]
    public IEnumerable<ConnectionProfileCrossAppAccessResourceAppStatusValueEnum>? AllowedValues { get; set; }

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
