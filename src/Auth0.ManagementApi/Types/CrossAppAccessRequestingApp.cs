using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configure the connection to be used as a Requesting Application for Cross App Access.
/// </summary>
[Serializable]
public record CrossAppAccessRequestingApp : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Set to `true` to enable the connection as a Requesting Application for Cross App Access. On `oidc` connections this requires `options.type` to be `back_channel`. Setting `false` is always accepted, so the role can be turned off even if the tenant or connection no longer supports it.
    /// </summary>
    [JsonPropertyName("active")]
    public required bool Active { get; set; }

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
