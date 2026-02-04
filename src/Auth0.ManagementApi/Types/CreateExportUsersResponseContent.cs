using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateExportUsersResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Status of this job.
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <summary>
    /// Type of job this is.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// When this job was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }

    /// <summary>
    /// ID of this job.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// connection_id of the connection from which users will be exported.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    [Optional]
    [JsonPropertyName("format")]
    public JobFileFormatEnum? Format { get; set; }

    /// <summary>
    /// Limit the number of records.
    /// </summary>
    [Optional]
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// List of fields to be included in the CSV. Defaults to a predefined set of fields.
    /// </summary>
    [Optional]
    [JsonPropertyName("fields")]
    public IEnumerable<CreateExportUsersFields>? Fields { get; set; }

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
