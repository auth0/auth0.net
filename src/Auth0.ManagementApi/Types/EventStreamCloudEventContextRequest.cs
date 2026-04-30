using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// An HTTP request.
/// </summary>
[Serializable]
public record EventStreamCloudEventContextRequest : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("geo")]
    public required EventStreamCloudEventContextRequestGeo Geo { get; set; }

    /// <summary>
    /// The hostname the request is for.
    /// </summary>
    [JsonPropertyName("hostname")]
    public required string Hostname { get; set; }

    /// <summary>
    /// The custom domain used in the request (if any).
    /// </summary>
    [Optional]
    [JsonPropertyName("custom_domain")]
    public string? CustomDomain { get; set; }

    /// <summary>
    /// The originating IP address of the request.
    /// </summary>
    [JsonPropertyName("ip")]
    public required string Ip { get; set; }

    /// <summary>
    /// The HTTP method used for the request.
    /// </summary>
    [JsonPropertyName("method")]
    public required string Method { get; set; }

    /// <summary>
    /// The value of the `User-Agent` header.
    /// </summary>
    [JsonPropertyName("user_agent")]
    public required string UserAgent { get; set; }

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
