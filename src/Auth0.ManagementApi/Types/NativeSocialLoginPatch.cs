using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configure native social settings
/// </summary>
[Serializable]
public record NativeSocialLoginPatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Nullable, Optional]
    [JsonPropertyName("apple")]
    public Optional<NativeSocialLoginApplePatch?> Apple { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("facebook")]
    public Optional<NativeSocialLoginFacebookPatch?> Facebook { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("google")]
    public Optional<NativeSocialLoginGooglePatch?> Google { get; set; }

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
