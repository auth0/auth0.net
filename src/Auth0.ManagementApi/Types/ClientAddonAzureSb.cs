using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Azure Storage Bus addon configuration.
/// </summary>
[Serializable]
public record ClientAddonAzureSb : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Your Azure Service Bus namespace. Usually the first segment of your Service Bus URL (e.g. `https://acme-org.servicebus.windows.net` would be `acme-org`).
    /// </summary>
    [Optional]
    [JsonPropertyName("namespace")]
    public string? Namespace { get; set; }

    /// <summary>
    /// Your shared access policy name defined in your Service Bus entity.
    /// </summary>
    [Optional]
    [JsonPropertyName("sasKeyName")]
    public string? SasKeyName { get; set; }

    /// <summary>
    /// Primary Key associated with your shared access policy.
    /// </summary>
    [Optional]
    [JsonPropertyName("sasKey")]
    public string? SasKey { get; set; }

    /// <summary>
    /// Entity you want to request a token for. e.g. `my-queue`.'
    /// </summary>
    [Optional]
    [JsonPropertyName("entityPath")]
    public string? EntityPath { get; set; }

    /// <summary>
    /// Optional expiration in minutes for the generated token. Defaults to 5 minutes.
    /// </summary>
    [Optional]
    [JsonPropertyName("expiration")]
    public int? Expiration { get; set; }

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
