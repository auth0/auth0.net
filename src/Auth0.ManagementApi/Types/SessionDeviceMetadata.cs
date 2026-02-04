using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Metadata related to the device used in the session
/// </summary>
[Serializable]
public record SessionDeviceMetadata : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// First user agent of the device from which this user logged in
    /// </summary>
    [Optional]
    [JsonPropertyName("initial_user_agent")]
    public string? InitialUserAgent { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("initial_ip")]
    public Optional<string?> InitialIp { get; set; }

    /// <summary>
    /// First autonomous system number associated with this session
    /// </summary>
    [Optional]
    [JsonPropertyName("initial_asn")]
    public string? InitialAsn { get; set; }

    /// <summary>
    /// Last user agent of the device from which this user logged in
    /// </summary>
    [Optional]
    [JsonPropertyName("last_user_agent")]
    public string? LastUserAgent { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("last_ip")]
    public Optional<string?> LastIp { get; set; }

    /// <summary>
    /// Last autonomous system number from which this user logged in
    /// </summary>
    [Optional]
    [JsonPropertyName("last_asn")]
    public string? LastAsn { get; set; }

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
