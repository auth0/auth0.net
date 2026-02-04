using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record LogStreamHttpSink : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// HTTP Authorization header
    /// </summary>
    [Optional]
    [JsonPropertyName("httpAuthorization")]
    public string? HttpAuthorization { get; set; }

    [Optional]
    [JsonPropertyName("httpContentFormat")]
    public LogStreamHttpContentFormatEnum? HttpContentFormat { get; set; }

    /// <summary>
    /// HTTP Content-Type header
    /// </summary>
    [Optional]
    [JsonPropertyName("httpContentType")]
    public string? HttpContentType { get; set; }

    /// <summary>
    /// HTTP endpoint
    /// </summary>
    [JsonPropertyName("httpEndpoint")]
    public required string HttpEndpoint { get; set; }

    /// <summary>
    /// custom HTTP headers
    /// </summary>
    [Optional]
    [JsonPropertyName("httpCustomHeaders")]
    public IEnumerable<HttpCustomHeader>? HttpCustomHeaders { get; set; }

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
