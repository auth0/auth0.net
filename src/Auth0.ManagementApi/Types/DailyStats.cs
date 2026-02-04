using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record DailyStats : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Date these events occurred in ISO 8601 format.
    /// </summary>
    [Optional]
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    /// <summary>
    /// Number of logins on this date.
    /// </summary>
    [Optional]
    [JsonPropertyName("logins")]
    public int? Logins { get; set; }

    /// <summary>
    /// Number of signups on this date.
    /// </summary>
    [Optional]
    [JsonPropertyName("signups")]
    public int? Signups { get; set; }

    /// <summary>
    /// Number of breached-password detections on this date (subscription required).
    /// </summary>
    [Optional]
    [JsonPropertyName("leaked_passwords")]
    public int? LeakedPasswords { get; set; }

    /// <summary>
    /// Date and time this stats entry was last updated in ISO 8601 format.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public string? UpdatedAt { get; set; }

    /// <summary>
    /// Approximate date and time the first event occurred in ISO 8601 format.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

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
