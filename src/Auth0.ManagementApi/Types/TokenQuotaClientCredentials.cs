using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The token quota configuration
/// </summary>
[Serializable]
public record TokenQuotaClientCredentials : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// If enabled, the quota will be enforced and requests in excess of the quota will fail. If disabled, the quota will not be enforced, but notifications for requests exceeding the quota will be available in logs.
    /// </summary>
    [Optional]
    [JsonPropertyName("enforce")]
    public bool? Enforce { get; set; }

    /// <summary>
    /// Maximum number of issued tokens per day
    /// </summary>
    [Optional]
    [JsonPropertyName("per_day")]
    public int? PerDay { get; set; }

    /// <summary>
    /// Maximum number of issued tokens per hour
    /// </summary>
    [Optional]
    [JsonPropertyName("per_hour")]
    public int? PerHour { get; set; }

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
