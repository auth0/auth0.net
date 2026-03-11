using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Create a connection with strategy=sms
/// </summary>
[Serializable]
public record CreateConnectionRequestContentSms : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("strategy")]
    public required CreateConnectionRequestContentSmsStrategy Strategy { get; set; }

    [Optional]
    [JsonPropertyName("options")]
    public ConnectionOptionsSms? Options { get; set; }

    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }

    [Optional]
    [JsonPropertyName("enabled_clients")]
    public IEnumerable<string>? EnabledClients { get; set; }

    [Optional]
    [JsonPropertyName("is_domain_connection")]
    public bool? IsDomainConnection { get; set; }

    [Optional]
    [JsonPropertyName("metadata")]
    public Dictionary<string, string?>? Metadata { get; set; }

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
