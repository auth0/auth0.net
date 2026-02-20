using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetJobResponseContent : IJsonOnDeserialized, IJsonOnSerializing
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
    /// connection_id of the connection this job uses.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    /// <summary>
    /// URL to download the result of this job.
    /// </summary>
    [Optional]
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// Completion percentage of this job.
    /// </summary>
    [Optional]
    [JsonPropertyName("percentage_done")]
    public int? PercentageDone { get; set; }

    /// <summary>
    /// Estimated time remaining before job completes.
    /// </summary>
    [Optional]
    [JsonPropertyName("time_left_seconds")]
    public int? TimeLeftSeconds { get; set; }

    [Optional]
    [JsonPropertyName("format")]
    public JobFileFormatEnum? Format { get; set; }

    /// <summary>
    /// Status details.
    /// </summary>
    [Optional]
    [JsonPropertyName("status_details")]
    public string? StatusDetails { get; set; }

    [Optional]
    [JsonPropertyName("summary")]
    public GetJobSummary? Summary { get; set; }

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
