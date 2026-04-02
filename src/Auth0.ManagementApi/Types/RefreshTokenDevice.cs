using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Device used while issuing/exchanging the refresh token
/// </summary>
[Serializable]
public record RefreshTokenDevice : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// First IP address associated with the refresh token
    /// </summary>
    [Optional]
    [JsonPropertyName("initial_ip")]
    public string? InitialIp { get; set; }

    /// <summary>
    /// First autonomous system number associated with the refresh token
    /// </summary>
    [Optional]
    [JsonPropertyName("initial_asn")]
    public string? InitialAsn { get; set; }

    /// <summary>
    /// First user agent associated with the refresh token
    /// </summary>
    [Optional]
    [JsonPropertyName("initial_user_agent")]
    public string? InitialUserAgent { get; set; }

    /// <summary>
    /// Last IP address associated with the refresh token
    /// </summary>
    [Optional]
    [JsonPropertyName("last_ip")]
    public string? LastIp { get; set; }

    /// <summary>
    /// Last autonomous system number associated with the refresh token
    /// </summary>
    [Optional]
    [JsonPropertyName("last_asn")]
    public string? LastAsn { get; set; }

    /// <summary>
    /// Last user agent associated with the refresh token
    /// </summary>
    [Optional]
    [JsonPropertyName("last_user_agent")]
    public string? LastUserAgent { get; set; }

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
