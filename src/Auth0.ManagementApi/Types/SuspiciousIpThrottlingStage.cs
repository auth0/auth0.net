using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Holds per-stage configuration options (max_attempts and rate).
/// </summary>
[Serializable]
public record SuspiciousIpThrottlingStage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("pre-login")]
    public SuspiciousIpThrottlingPreLoginStage? PreLogin { get; set; }

    [Optional]
    [JsonPropertyName("pre-user-registration")]
    public SuspiciousIpThrottlingPreUserRegistrationStage? PreUserRegistration { get; set; }

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
