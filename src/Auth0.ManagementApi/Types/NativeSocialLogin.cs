using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configure native social settings
/// </summary>
[Serializable]
public record NativeSocialLogin : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("apple")]
    public NativeSocialLoginApple? Apple { get; set; }

    [Optional]
    [JsonPropertyName("facebook")]
    public NativeSocialLoginFacebook? Facebook { get; set; }

    [Optional]
    [JsonPropertyName("google")]
    public NativeSocialLoginGoogle? Google { get; set; }

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
