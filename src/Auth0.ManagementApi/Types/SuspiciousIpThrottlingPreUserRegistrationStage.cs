using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration options that apply before every user registration attempt.
/// </summary>
[Serializable]
public record SuspiciousIpThrottlingPreUserRegistrationStage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Total number of attempts allowed.
    /// </summary>
    [Optional]
    [JsonPropertyName("max_attempts")]
    public int? MaxAttempts { get; set; }

    /// <summary>
    /// Interval of time, given in milliseconds, at which new attempts are granted.
    /// </summary>
    [Optional]
    [JsonPropertyName("rate")]
    public int? Rate { get; set; }

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
