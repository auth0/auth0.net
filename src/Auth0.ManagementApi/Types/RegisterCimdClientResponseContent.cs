using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Response after successfully registering or updating a CIMD client
/// </summary>
[Serializable]
public record RegisterCimdClientResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The Auth0 client_id of the created or updated client
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [JsonPropertyName("mapped_fields")]
    public required CimdMappedClientFields MappedFields { get; set; }

    [JsonPropertyName("validation")]
    public required CimdValidationResult Validation { get; set; }

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
