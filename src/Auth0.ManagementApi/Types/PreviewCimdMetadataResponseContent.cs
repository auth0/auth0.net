using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record PreviewCimdMetadataResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The client_id of an existing client registered with this external_client_id, if one exists.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// Array of retrieval errors (populated when the metadata document could not be fetched). When present, validation is omitted.
    /// </summary>
    [Optional]
    [JsonPropertyName("errors")]
    public IEnumerable<string>? Errors { get; set; }

    [Optional]
    [JsonPropertyName("validation")]
    public CimdValidationResult? Validation { get; set; }

    [Optional]
    [JsonPropertyName("mapped_fields")]
    public CimdMappedClientFields? MappedFields { get; set; }

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
