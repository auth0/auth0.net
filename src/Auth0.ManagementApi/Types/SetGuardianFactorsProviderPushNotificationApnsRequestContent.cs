using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record SetGuardianFactorsProviderPushNotificationApnsRequestContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("sandbox")]
    public bool? Sandbox { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("bundle_id")]
    public Optional<string?> BundleId { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("p12")]
    public Optional<string?> P12 { get; set; }

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
